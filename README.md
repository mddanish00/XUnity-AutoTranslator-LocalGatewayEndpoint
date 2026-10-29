<a id="readme-top"></a>
<br />
<div align="center">
<h3 align="center">XUnity-AutoTranslator-LocalGatewayEndpoint</h3>

  <p align="center">

LLM-backed (by Local AI Gateway) translator endpoint for [XUnity.Auto.Translator](https://github.com/bbepis/XUnity.AutoTranslator).

  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#building">Building</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project

This project aimed to add LLM translation from Local AI Gateway for [XUnity.Auto.Translator](https://github.com/bbepis/XUnity.AutoTranslator). I focused on local because some game do not support HTTPS, so by using local instead make this Endpoint more usable. There are also added convienence like auto-launch gateway when you opened the game (when XUAT is loaded).

Of course, you can just use [XUnity.AutoTranslate.LlmTranslators](https://github.com/joshfreitas1984/XUnity.AutoTranslate.LlmTranslators) which this project is based on.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

This project needed XUnity-AutoTranslator v5.0.0 or higher to works. Usually, this already came included with the translation mod for your game. Refer to [XUAT Installation](https://github.com/bbepis/XUnity.AutoTranslator#installation) for installing XUAT manually.

You also need to set up an local AI Gateway.

> Only supported local AI Gateway right now are agentgateway and LiteLLM. Author recomendation is agentgateway. Created in Rust and fast program intialization comapred to LiteLLM. (LiteLLM takes 1-2 min on my weak PC)

### Installation

1. Download pre-compiled dll from Releases and install into `XUnity.AutoTranslator\Translators` folder. (The folder location may different based on mod loader you are using to use for XUAT.)

2. Copy the `SampleConfig/LocalGateway` folder to your loader config folder. For example, for BepInEx, in `BepInEx/config`.

    > DLL Release is compiled with the pinned version of XUnity-AutoTranslator. (Usually, whatever is the latest version at the time of commit.)

3. Backup your XUAT configuration file (`AutoTranslatorConfig.ini`). After you have a backup copy, edit the configuration and change the `Endpoint` setting to `LocalGateway`.  Your `[Service]` section should look like this:

    ```ini
    [Service]
    Endpoint=LocalGateway
    FallbackEndpoint=
    ```

4. Add the configuration for this project. Refer to [Configuration](#configuration) section.

5. Open your game and enjoy! ❤️

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->
## Usage

### Configuration

Example config in `AutoTranslatorConfig.ini`.

```ini
[LocalGateway]
ServerPort=4000
BinaryPath=C:\Users\User\.local\bin\litellm.exe
BinaryArguments=file=config=C:\Users\User\Desktop\litellm-config.yaml
ApiKey=sk-67696769
ModelName=gpt-oss-20b
ModelParams=temperature=0.2;top_p=0.9;frequency_penalty=0;presence_penalty=0
UseExternalServer=False
LogServerMessages=False
```

- `ServerPort`: Port used to launch and communicate with the server.
- `BinaryPath`: Path to your preferred local gateway binary.
- `BinaryArguments`: Arguments to be passed to the binary when launching the server. Do not use short options (`-c`, `-b`).

> Both agentgateway and LiteLLM needs to be explicitly pointed toward config and added to `BinaryArguments`. For agentgateway, `file=C:\Users\User\.config\agentgateway\config.yaml`. For LiteLLM, `config=litellm-config.yaml`.

- `ApiKey`: API Key to access the server.
- `ModelName`: Model to use for translation.
- `ModelParams`: Model customization for this translation task.
- `UseExternalServer`: Use external local gateway Proxy server instead. If enabled, both `BinaryPath` and `BinaryArguments` will be skipped.
- `LogServerMessages`: Log Local Gateway server message in XUAT console.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

## Building

For developers, it is recommended to use your project XUnity-AutoTranslator DLL to build this project as long it meet the requirements for maximum compatibility.

- Use latest Windows (optional for maximum compatibility)
- Make sure latest .NET SDK is installed.
- XUnity-AutoTranslator v5.0.0 or higher.
- Download XUnity.AutoTranslator-Developer-X.X.X.zip.
- If you using IL2CPP, download XUnity.AutoTranslator-Developer-IL2CPP-X.X.X.zip instead.
- If you want to use your project DLLs, put DLLs in libs folder or libs-il2cpp if using il2cpp.

### Normal Version

1. Unzip XUnity.AutoTranslator-Developer-X.X.X.zip in this repo. Rename `Developer` folder to `libs`.
2. Run the build command.

    ```cmd
    dotnet build -c Release -v n -f net35
    ```

3. Copy the builded DLL, `LocalGatewayEndpoint\bin\Release\net35\LocalGateway.dll` to your project `XUnity.AutoTranslator\Translators` folder.

### IL2CPP Version

1. Unzip XUnity.AutoTranslator-Developer-IL2CPP-X.X.X.zip in this repo. Rename `Developer` folder to `libs-il2cpp`.
2. Run the build command.

    ```cmd
    dotnet build -c Release -v n -f net6.0
    ```

3. Copy the builded DLL, `LocalGatewayEndpoint\bin\Release\net6.0\LocalGateway.dll` to your project `XUnity.AutoTranslator\Translators` folder.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
## License

Distributed under the MIT License. See [`LICENSE`](./LICENSE) for more information.

Some of this project code are based on [XUnity.AutoTranslate.LlmTranslators](https://github.com/joshfreitas1984/XUnity.AutoTranslate.LlmTranslators) project, licensed under [MIT](https://raw.githubusercontent.com/joshfreitas1984/XUnity.AutoTranslate.LlmTranslators/refs/heads/master/LICENSE) and [XUnity-AutoTranslator-StasServerEndpoint](https://github.com/mddanish00/XUnity-AutoTranslator-StasServerEndpoint) project, licensed under [MIT](https://raw.githubusercontent.com/mddanish00/XUnity-AutoTranslator-StasServerEndpoint/refs/heads/main/LICENSE) which is a fork of [XUnity-AutoTranslator-SugoiOfflineTranslatorEndpoint](https://github.com/Vin-meido/XUnity-AutoTranslator-SugoiOfflineTranslatorEndpoint) project.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

- Thanks to [joshfreitas1984](https://github.com/joshfreitas1984) for [XUnity.AutoTranslate.LlmTranslators](https://github.com/joshfreitas1984/XUnity.AutoTranslate.LlmTranslators).
- Thanks to [Vin-meido](https://github.com/Vin-meido) for [XUnity-AutoTranslator-SugoiOfflineTranslatorEndpoint](https://github.com/Vin-meido/XUnity-AutoTranslator-SugoiOfflineTranslatorEndpoint).

<p align="right">(<a href="#readme-top">back to top</a>)</p>
