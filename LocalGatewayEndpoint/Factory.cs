/*
MIT License

Copyright (c) 2026 mddanish00

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SimpleJSON;

namespace LocalGateway
{
    public class FactoryTuple<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }

        public FactoryTuple(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }
    public static class Factory
    {
        public static string GetRequestData(string raw)
        {
            var systemPrompt = new StringBuilder(Configuration.config.SystemPrompt);
            var appendItem = ConstructGlossaryPrompt(raw);
            if (appendItem.Item1 > 0)
                systemPrompt.AppendLine(appendItem.Item2);

            // Create messages using SimpleJSON
            var messages = new JSONArray();
            var systemMessage = new JSONObject();
            systemMessage["role"] = "system";
            systemMessage["content"] = systemPrompt.ToString();
            messages.Add(systemMessage);

            var userMessage = new JSONObject();
            userMessage["role"] = "user";
            userMessage["content"] = raw;
            messages.Add(userMessage);

            // Create the requestBody object using SimpleJSON
            var requestBody = new JSONObject
            {
                ["model"] = Configuration.modelConfig.Model,
                ["stream"] = false,
                ["messages"] = messages
            };

            foreach (var param in Configuration.modelConfig.ModelParams)
            {
                if (decimal.TryParse(param.Value.ToString(), out decimal isDecimal))
                    requestBody[param.Key] = (double)isDecimal;
                else if (int.TryParse(param.Value.ToString(), out int isInt))
                    requestBody[param.Key] = isInt;
                else
                    requestBody[param.Key] = param.Value.ToString();
            }

            return requestBody.ToString();
        }

        public static FactoryTuple<int, string> ConstructGlossaryPrompt(string raw)
        {
            var prompt = new StringBuilder(Configuration.config.GlossaryPrompt);
            var appendItem = AppendPromptsFor(raw, Configuration.config.GlossaryLines);
            prompt.AppendLine(appendItem.Item2);
            return new FactoryTuple<int, string>(appendItem.Item1, prompt.ToString());
        }

        private static FactoryTuple<int, string> AppendPromptsFor(string raw, List<GlossaryLine> glossaryLines)
        {
            var prompt = new StringBuilder();
            var appendCount = 0;

            foreach (var line in glossaryLines)
            {
                if (raw.Contains(line.Raw))
                {
                    if (string.IsNullOrEmpty(line.Context) == false)
                        prompt.Append($"- {line.Raw}: {line.Result} (Context: {line.Context})\n");
                    else
                        prompt.Append($"- {line.Raw}: {line.Result}\n");

                    appendCount++;
                }
            }

            return new FactoryTuple<int, string>(appendCount, prompt.ToString());
        }

        public static string ValidateAndCleanupTranslation(string raw, string result)
        {
            // If we do any other clean up should be done here
            if ((result.StartsWith("\"") && result.EndsWith("\""))
                || (result.StartsWith("'") && result.EndsWith("'")))
                result = result.Substring(1, result.Length - 2);

            //Take out wide quotes
            result = result
                .Replace("’", "'")
                .Replace("‘", "'");

            result = Regex.Unescape(result);

            // Return empty string if result is null or empty
            if (string.IsNullOrEmpty(result))
                return string.Empty;

            // Make sure first character is upper case
            if (Char.IsLower(result[0]) && raw != result)
                result = Char.ToUpper(result[0]) + result.Substring(1, result.Length - 1);

            return result.Trim();
        }

        // Example -> WhateverArray=reload;request_timeout=30;run_gunicorn;num_workers=4
        public static string[] GetIniArray(string iniString)
        {
            if (string.IsNullOrEmpty(iniString))
                return new string[0];

            var lines = iniString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<string>();

            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                if (!string.IsNullOrEmpty(trimmedLine))
                    result.Add(trimmedLine);
            }

            return result.ToArray();
        }
    }
}