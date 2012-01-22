# CMContrib
 Components that extend [Caliburn.Micro](http://caliburnmicro.codeplex.com/)

## Setup
After cloning the repository, run the *update_packages.ps1* PowerShell-Script in the root folder to get all required NuGet packages.

## Nuget Package
To create the CMContrib NuGet Package, just follow these steps 

1. Build the Solution with **Release** Configuration
2. Run the *create-packages.ps1* PowerShell-Script in the ~/nuget/ folder. 

You can find the .nuspec  file in ~/nuget/package/ if you need to edit the metadata (version).

## Features
### MVVM Dialogs
Easy way to show dialogs to the user. There are four predefined Dialogs

- Information
- Warning
- Question
- Error
 
For more Information see [Blog post](http://kmees.github.com/blog/2011/06/16/mvvm-dialogs-with-caliburn-dot-micro/).


### IResult Implementation

####SL & WPF:

- BusyResult - Locates an implementation of IBusyIndicator by searching the Visual Tree or by injecting it and activates/deactivates it.
- DialogResult - Creates a modal DialogWindow for a Dialog, shows it to the user and stroes the response in a Property. Also enables you to automatically cancel the result for a specific answer.
- OpenChildResult - Activate a ViewModel in a specific Conductor
- DelegateResult - Wraps an arnitrary Action in a Result.

####WPF only:

- SaveFileResult - Result wrapper for a SaveFileDialog with fluent configuration
- OpenFileResult - Result wrapper for an OpenFileDialog with fluent configuration
- BrowseFolderResult - Result wrapper for a BroseFolderDialog with fluent configuration

### IResult Extensions
CMContrib provides several chainable Extension Methods for IResult

- Rescue&lt;TException&gt;() - Decorates the result with an error handler which is executed when an error occurs.
- WhenChancelled() - Decorates the result with an handler which is executed when the result was cancelled.
- AsCoroutine() - Returns an IEnumerable&lt;IResult&gt; which yields the IResult.
- OnWorkerThread - Executes the Result on a dedicated worker thread and activates the given IBusyIndactor when a message is given.

### Filter
Filters are part of the bigger Caliburn framework. They are quite useful because they enable AOP for coroutine. Some of them are re-implemented

- Rescue - Decorates the coroutine with an error handler which es executed when an error occurs during execution
- Async - Delegates the execution of the coroutine to a background thread
- Busy - Extends the Async Filter activating the IBusyIndicator before the coroutine gets executed and deactivating it after the execution

## Examples
For every Feature there exists an example implementation in the Demo projects (SL&WPF)