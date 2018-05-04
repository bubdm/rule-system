_**This project is not looking for contributors during this early development phase. However, if you
really feel you must be a part of this project at this stage then contact a project coordinator.
This document will be modified and become more detailed prior to accepting general contributors.**_

# Contributing

## Environment

- VisualStudio 2017
- .NET Core 2.0

## Code Style

- private/protected member variable should begin with an underscore
- verbatim identifiers should only be used for @this with extension methods
- https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions
- https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/

## Commit Message Style

```
Short summary of 72 chars or less

More detailed explanation of commit wrapped to 72 characters. 
There must be a blank line separating the summary from any 
detailed explanations.

Multiple paragraphs are allowed; separate them with a blank line.
The summary of the commit message should be written in the
imperative: "Change feature" not "Changed feature" or "Changes
feature."

- You can use bullet points.
- And refernece issues and pull requests.
```

### Short Summary

A good short summary should be able to complete the following sentence:

**If applied, this commit will _&lt;your summary here&gt;_**

- Do not end the subject line with a period

### Detailed Explanation

- Use the detailed explanation for ***why*** the change was made, in most cases it isn't
  necessary to explain *how* the change was made.
- How does this address the issue
- Are there any side effects