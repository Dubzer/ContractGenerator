# Contract Generator

To deploy you need .NET Core 3.1 SDK

To create template, follow README.md in this repository: https://github.com/UNIT6-open/TemplateEngine.Docx

## Making request

GET or POST:

`/api/v1/generate_contract?PARAMS_HERE`

For example, for a template in the repository request will look like:

`/api/v1/generate_contract?data=Wow! It works!`

You can use an unlimited number of parameters. The only requirement is that you have to match tag names.

Please note that you cannot create a request without params.
