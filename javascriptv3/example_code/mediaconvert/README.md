# TypeScript environment for Amazon Lambda examples
Environment for AWS SDK for JavaScript (V3) Amazon Elemental MediaConvert examples. For more information, see the [AWS documentation for these examples](https://docs.aws.amazon.com/sdk-for-javascript/v3/developer-guide/mediaconvert-examples.html).

AWS Elemental MediaConvert is a file-based video transcoding service with broadcast-grade features.

This is a workspace where you can find working AWS SDK for JavaScript (V3) AWS Elemental MediaConvert examples. 

**NOTE:** The AWS SDK for JavaScript (V3) is written in TypeScript so, for consistency, these examples are also in TypeScript. TypeScript is
a super-set of JavaScript so these examples can also be run as JavaScript.


# Getting started

1. Clone the [AWS SDK Code Samples repo](https://github.com/awsdocs/aws-doc-sdk-examples) repo to your local environment. See [here](https://docs.github.com/en/github/creating-cloning-and-archiving-repositories/cloning-a-repository) for instructions.

2. Install the dependencies listed in the package.json.

**Note**: These include the client module for the AWS services required in these example, 
which is *@aws-sdk/client-mediaconvert*.
```
npm install ts-node -g // If using JavaScript, enter 'npm install node -g' instead
cd javascriptv3/example_code/mediaconvert
npm install
```

3. If you're using JavaScript, change the sample file extension from ```.ts``` to ```.js```.
- Change the sample file extension from ```.ts``` to ```.js```
- Remove the ```module.exports ={*}``` statement from the sample file

4. In your text editor, update user variables specified in the ```Inputs``` section of the sample file.

5. Run sample code:
```
cd src
ts-node [example name].ts // e.g., ts-node iam_accesskeylastused.ts
```
