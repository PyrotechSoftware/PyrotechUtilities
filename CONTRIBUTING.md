# ![PyrotechUtilities](content/PyrotechUtilities-GitHub-NoBg.png)

<!-- TOC start (generated with https://github.com/derlin/bitdowntoc) -->

- [Information and Guidelines for Contributors](#information-and-guidelines-for-contributors)
   * [Code of Conduct](#code-of-conduct)
   * [Minimal Prerequisites to Compile from Source](#minimal-prerequisites-to-compile-from-source)
   * [Pull Requests](#pull-requests)
      + [Pull Requests which introduce new components](#pull-requests-which-introduce-new-components)
   * [Coding Dos and Don'ts](#coding-dos-and-donts)
   * [Unit Testing and Continuous Integration](#unit-testing-and-continuous-integration)
      + [How not to break stuff](#how-not-to-break-stuff)
      + [Make your code break-safe](#make-your-code-break-safe)
      + [How to write a unit test?](#how-to-write-a-unit-test)
      + [What does not need to be tested?](#what-does-not-need-to-be-tested)
      + [Continuous Integration](#continuous-integration)

<!-- TOC end -->

# Information and Guidelines for Contributors
Thank you for contributing to PyrotechUtilities and making it even better. We are happy about every contribution! Issues, bug-fixes, new components...

## Code of Conduct
Please make sure that you follow our [code of conduct](/CODE_OF_CONDUCT.md)

## Minimal Prerequisites to Compile from Source

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Pull Requests
- Your Pull Request (PR) must only consist of one topic. It is better to split Pull Requests with more than one feature or bug fix in seperate Pull Requests
- First fork the repository and clone your fork locally to make your changes. (The main repository is protected and does not accept direct commits.)
- You should work on a seperate branch with a descriptive name. The following naming convention can be used: `feature/my-new-feature` for new features and enhancements, `fix/my-bug-fix` for bug fixes. For example `fix/button-hover-color` if your PR is about a bug involving the hover color of buttons
- You should build, test and run one of the Docs projects locally to confirm your changes give the expected result. We generally suggest the PyrotechUtilities.Docs.Server project for the best debugging experience.
- Choose `dev` as the target branch
- All tests must pass, when you push, they will be executed on the CI server and you'll receive a test report per email. But you can also execute them locally for quicker feedback.
- You must include tests when your Pull Requests alters any logic. This also ensures that your feature will not break in the future under changes from other contributors. For more information on testing, see the appropriate section below
- If there are new changes in the main repo, you should either merge the main repo's (upstream) dev or rebase your branch onto it.
- Before working on a large change, it is recommended to first open an issue to discuss it with others
- If your Pull Request is still in progress, convert it to a draft Pull Request
- The PR Title should follow the following format: 
```
<utility name>: <short description of changes in imperative> (<linked issue>)
```
For example:
```
 DateOnlyExtensions: Add Nullable Types (#1997)
```
- To keep your branch up to date with the `dev` branch simply merge `dev`. **Don't rebase** because if you rebase the wrong direction your PR will include tons of unrelated commits from dev.
- Your Pull Request should not include any unnecessary refactoring
- If there are visual changes, you should include a screenshot, gif or video
- If there are any coresponding issues, link them to the Pull Request. Include `Fixes #<issue nr>` for bug fixes and `Closes #<issue nr>` for other issues in the description ([Link issues guide](https://docs.github.com/en/github/managing-your-work-on-github/linking-a-pull-request-to-an-issue#linking-a-pull-request-to-an-issue-using-a-keyword)) 
- Your code should be formatted correctly ([Format documentation](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/style-rules/formatting-rules))


## Coding Dos and Don'ts
- **Don't break stuff!** See section *Unit Testing and Continuous Integration* below
- **Add a test to guard against others breaking your feature/fix!** See section *Unit Testing and Continuous Integration* below

## Unit Testing and Continuous Integration

We strive for a complete test coverage in order to keep stuff from breaking and
delivering a rock solid library. For every component that has C# logic we 
require a bUnit test that is checking that logic.

### How not to break stuff

When you are making changes to any components and preparing a PR make
sure you run the entire test suite to see if anything broke. 

### Make your code break-safe

When you are writing non-trivial logic, please add a unit test for it. Basically, think of it like this: By adding 
a test for everything you fear could break you make sure your work is not undone by accident by future additions. 

### How to write a unit test?

It is actually dead simple. Look at some of the simpler tests like 
- NumericExtensionsTests.cs for normal C# tests

### Continuous Integration

We have a Github Actions pipeline which will automatically execute the entire
test suite on all pushes and PRs. So if your commit or PR breaks the tests
you'll be notified.