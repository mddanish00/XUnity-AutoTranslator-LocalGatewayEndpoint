# Changelog

## 1.0.0 (2026-11-12)


### Features

* add configuration loading and model parameters to LiteLLMEndpoint ([bcd6cec](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/bcd6cec54f41d95ca7d7df509068c49fef3637b5))
* add replacing some glossary terms before translating ([0e130f7](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/0e130f744c67bd407198e6a695e518dc306b94db))
* add UseExternalServer configuration and update request URL for LiteLLMEndpoint ([d18e0d7](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/d18e0d730b4ddad10c57c81e07c854f9e9e7b8a9))
* add YamlDotNet and ILRepack references with build target configuration ([d0e8749](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/d0e8749840698543cb8e544092dc96afb036223c))
* append Context in Glossary Lines ([b4ce47f](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/b4ce47f35643077c3a03f09d30f10b6d9ea6abbf))
* change name to LocalGateway ([07200c6](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/07200c6a36c4c4e99c4845aabac4b1b51960aa51))
* changing to make config not specific to LiteLLM ([07200c6](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/07200c6a36c4c4e99c4845aabac4b1b51960aa51))
* do not append Glossary if list is empty ([27971ad](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/27971adc7f74e84246b511f555bcf4d43b7fa08c))
* enhance configuration and request handling for LiteLLMEndpoint ([351c003](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/351c003d27ae08589ab1511391fda266e066e908))
* enhance LiteLLMEndpoint with process management and logging ([aaf8089](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/aaf80899d6db55c67a7644b2f3390e77d61f666f))
* enhance text substitution logic to preserve original text if not translatable ([8778eb8](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/8778eb8f6248e47ffb1503cd12f77ad63890a09a))
* handle translation failure in LocalGatewayEndpoint ([020f535](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/020f5356d3e9a9ad13a3eb3fa8ad8e90aa4faf56))
* implement GetIniArray method for parsing INI strings and update ExtraArguments handling ([bac2655](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/bac2655e872654248d53ccec1a714dc92f9cb128))
* implement LiteLLMEndpoint initialization and configuration ([60eec15](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/60eec15acf5f3272e2e291428f7ac95e2966728f))
* properly check logs for server readiness ([dbc6452](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/dbc6452fc792add81dfcf8f57628e75c3cc2e597))
* set up initial function (not implemented yet) process management ([ae60c21](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/ae60c217a0f1bc9545c3d31180e7e685510d11d8))
* trim raw text when matching glossary ([63fb7cd](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/63fb7cdacee91692310b51f002eeec06d349fdf2))
* update glossary file handling to use JSON format and remove YamlDotNet dependency ([70225fc](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/70225fc69f212f29d08f6884688b327493cf56ef))


### Bug Fixes

* check grammar and misspelling using Harper ([e9671dd](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/e9671dd575c484168096d150b91e411eadda4770))
* empty translation output can throw an exception ([797a84c](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/797a84c331d0e8c1870ec651399bedeb032c0495))
* fix detection of server readiness ([67e30f1](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/67e30f16729e81acce8352979a1ed171152129db))
* fix successful request still trigger fail ([dcaedb5](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/dcaedb5e51f8b335bd7f9b817734121e2c6656d6))
* glossary parsing assumes valid JSON and valid node values ([3b5585e](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/3b5585e68251e6b11bb4ea0b1d7668fbc7d8e449))
* properly check glossary without matches ([e9e567f](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/e9e567f45444ed572848c353d8fb4f601a0cc4cd))
* replace generic exceptions with EndpointInitializationException for better error handling ([da5ce6b](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/da5ce6b1781fa946d8b111dcd708d8d3f0faddaf))
* update request URL to use 127.0.0.1 and add early exit for external server in translation process ([dbee93f](https://github.com/mddanish00/XUnity-AutoTranslator-LocalGatewayEndpoint/commit/dbee93f32e8c1035065c61b86a174a245829bb6c))
