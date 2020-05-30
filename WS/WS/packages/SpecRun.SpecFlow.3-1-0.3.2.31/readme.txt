3.2

Features:
- support new license model with the new SpecFlow Account 


Changes since 3.1.33

fixes:
- fix serialization error - https://github.com/techtalk/SpecFlow/issues/1788


3.1

Features:
- Support .NET Core 3.0
- Support for SpecFlow 3.1

Fixes:
- Executing in Docker works
- Performance for executing projects with a lot of scenarios (> 10000) improved

Changes:
- Changed the communication between main process and child processes from named pipes to TCP/IP


3.0 - 2019-09-16

Bugfixes:
- registration error in specflow-plus-license fixed

3.0.0 2019-04-17

Bugfixes:
- Fixes a bug where not all invalid file characters have been removed from report names
- Fixes a bug where the `report` parameter in the Console has been ignored
- Fixes a bug where the report displayed the number of failed test runs (including retries) instead of the wrong number of failed tests

Non-breaking changes:
- remove requirement of having a default.srprofile in the project
- remove default.srprofile from SpecFlow+ Runner packages (if you need to configure the behavior of SpecFlow+ Runner, you can create a .srprofile file with the template provided by the SpecFlow Extension for Visual Studio)

Breaking changes:
- The outputName value of report template configurations must not contain subfolders. Instead, use the `outputFolder` property in the `<Settings>` tag.


3.0.0 2019-02-20

New features:
- Support .NET Core 2.0, 2.1
- add DeleteFolder as a new Deployment transformation step

Behavior changes:
- If CLR 2.0 is specified as runtime, SpecFlow+ Runner will use the CLR 4.0 executor.

Bugfixes:
- Report: show correct successrate when a scenario is retried
- srProfile files aren't displayed double anymore
- display failing scenarios with at leat one pending or successful retry as randomly failed.

Breaking changes:
- move Report generation to a separate process
- change base class for reporting from `TechTalk.SpecRun.Framework.Reporting.CustomTemplateBase<TestRunResult>` to `SpecFlow.Plus.Runner.Reporting.CustomTemplateBase<TestRunResult>`

Removed features:
- remove support for combined test executors like SpecRun+NUnit and SpecRun+MsTest because of the new plugin infrastructure



1.8.5 2018-10-11

Bug fixes:
- fix `System.ArgumentException: Illegal characters in path.` in reporting module

1.8.4 2018-10-02

Bug fixes:
- additional logging

1.8.3 2018-09-27

Bug fixes:
- handle AppDomain Unload Exceptions, which prevents report generation

1.8.2 2018-08-25

Bug fixes:
- add missing report templates to the SpecRun.Runner package again

1.8.1 2018-08-24

New Features:
- remove install.ps1 script to set Default.srProfile to CopyIfNewer, using MSBuild infrastructure for this now

Bug fixes:
- fix MSBuild error MSB4066: The attribute "Update" in element <None> is unrecognized.


1.8.0 2018-08-20

New Features:
- Support for SpecFlow 2.4
- Support of VS 2017 15.8 TestAdapter discovery changes



1.7.2 2018-05-16

Bug fixes:
- fix reading of runsettings files - https://github.com/techtalk/SpecFlow/issues/1134
- allow slash (/) and backslash (\) again in report output name to support destination subfolders
- add missing entries in SpecRunTestProfile.xsd

1.7.1 2018-04-28

Bug fixes:
- fix report filename generation so that it will not use not allowed characters in a filename
- fix error in test output if you have more than one report defined - https://github.com/techtalk/SpecFlow/issues/1076#issuecomment-374636388
- fix error with reporting test result to Visual Studio if VSTest unified mode is used


1.7.0 2018-02-16

New Features:
- Support for SpecFlow 2.3
- Combine test results of retried tests to one (only when executed via VSTest) - https://github.com/techtalk/SpecFlow/issues/833 https://github.com/techtalk/SpecFlow/issues/836
- new Reporttemplate for Cucumber-Json format (Name: CucumberJson)
- adding TestRunContext to be available to get the location of your test assembly
- possibility to define the testThreadCount as 'max'. This uses then the number of cores - 1 as testThreadCount


Bug fixes:
- runtests.cmd - use msbuild.exe from path and not from %windir%\Microsoft.NET\Framework\v4.0.30319
- fixed that log entries get written into report file if you define the name of the report in a runsettings file
- VisualStudio.srProfile is used, if it exists and the test run is started from within VisualStudio

1.6.3 2017-10-03

Bug fixes:
- Fix CommunicationObjectFaultedException when using Process separation & DateTime - https://github.com/techtalk/SpecFlow/issues/945
- Fix CommunicationObjectFaultedException when having long running scenarios (> 10min) - https://stackoverflow.com/questions/46307110/specrun-timeout-on-test-execution-when-performing-a-selenium-wait-longer-than-10


1.6.2 2017-09-26

Bug fixes:
- Thread.Current.Name is again set to "Test Thread #<Number>" when you execute the tests in more than one thread
- Workaround for issue https://github.com/techtalk/SpecFlow/issues/935 and https://github.com/NuGet/Home/issues/5880


1.6.1 2017-09-12

New Features:
- Support for "Run functional Tests"- Task on TFS/VSTS

Bug fixes:
- System.NullReferenceException during parse [BeforeFeature] hook with FeatureContext parameter - https://github.com/techtalk/SpecFlow/issues/886
- Executing tests fails if the project path contains a # characters
- Tests are duplicated/doubled up in Visual Studio Test Explorer - https://github.com/techtalk/SpecFlow/issues/900


1.6.0 2017-06-20

Re- Release of 1.6.0-rc007 as 1.6.0

1.6.0-rc007 2017-06-07

Bug fixes:
- Filters for functional tests now use same syntax as everywhere else

1.6.0-rc006 2017-05-23

New Features
- Support for SpecFlow 2.2.0-preview20170523

1.6.0-rc005 2017-05-10

New Features
- Support for SpecFlow 2.2.0-preview20170510
- Duration of Scenarios and Features are displayed when using the standard report template

1.6.0-rc003 2017-01-09

New Features
- Support for Visual Studio 2017 RC (tested with 15.0.25928.0 D15REL)
    Known Issues:
        - No tests are found if lightweight load is enabled
        - If XUnit or MSTest test runners are used, no tests are found

Bug fixes:
- XML Report template additions (scenario tags)


1.6.0-rc002 2016-11-23

New Features
- New configuration setting to handle conflicts with existing report files with the same name (overwrite, rename)
- Support for placeholders in the report file names (current date and time, project GUID)

Bug fixes:
- Fixed a bug that occurred when combining SharedAppDomain isolation and targets (https://groups.google.com/d/msg/specrun/GeVoqsHlmNY/TbnvbfSoAwAJ)


1.6.0-rc001 2016-10-20
New Features
- Report template for JSON output
- Report template for XML output
- Added option for CopyFolder DeploymentStep to disable cleanup of target folder before copying

Bug fixes:
- Execution via Visual Studio TestAdapter (VS or TFS) now takes into account entries in TestAssemblyPaths and no longer executes all given assemblies.
- testpath filter works now with colon (:) in scenario title
- Use projectName if no name is given in srProfile as project name in SpecFlow+Server


1.5.2 2016-07-07
Bug fixes:
- Links to custom files in reports
- VS 2013 Debugger asks for source files of SpecFlow+Runner at stepping through bindings


1.5.0 2016-06-15
New features:
- Generate multiple reports from a single test run
- Formatting fixes in report output


1.4.1 - 2016-05-30

Bug fixes:
- Bugfix for error when using SpecRun+MsTest/SpecRun+NUnit Unit test provider and running the tests with MsTest/NUnit.


1.4.0 - 2016-05-24

New features:
- Support for SpecFlow V2's Shared AppDomain parallelization 
- Output additional license info (expiry date, upgrade until date) when running from the console

Bug fixes:
- Under certain conditions, failed tests are not retried
- In Visual Studio 2015 Update 2 not all tags where displayed as traits


1.3.0 - 2016-01-27

New features:
- Visual Studio 2015 support
- VB.Net support
- Support for project licenses
- Added completion state to console title
- Default report template included (ReportTemplate.cshtml)
- API for stopping the test run
- TechTalk.SpecRun.dll is now signed
- Error message if filter syntax is incorrect
- Add new setting to copy the report to the base folder (<Report copyAlsoToBaseFolder="true"/>)


Bug fixes:
- Escape '<' and '>' correctly in Visual Studio Test discovery
- Fixed an occurance of locking an assembly
- Fixed an issue with adaptive test scheduling and tests with a long history
- Enabled useLegacyV2RuntimeActivationPolicy="true" on test executor to support multi-mode assemblies by default 
- Use more than 64 threads for test run


1.2.0 - 2013-8-16

New features:
- Visual Studio test explorer integration - SpecRun test can be executed directly from Visual Studio 2012 without 
  any additional configuration (the NuGet package contains all necessary integration infrastructure). See US49 in the documentation for 
  details ("docs" folder of the NuGet package).
- TFS integration - SpecRun tests can be executed by Team Foundation Server builds without additional configuration. 
  See US51 for details.
- Test Targets: allow running tests multiple times with different environment or configuration settings
  See US17 for details.
- Service wrapper to run SpecRun server as a Windows service (SpecRun.Server.Service.exe).
- Regex-based tag filtering - use the expression tagmatch:some-regex to filter for tags in any test filtering expression. 
  E.g. tagmatch:bug\d+ matches for tags like @bug1234 or @bug456
- Allow execution of test assemblies with .NET 3.5 environment (.NET 2.0 CLR), configurable in the profile
- Allow execution of test assemblies with x86 and x64 platform, configurable in the profile
- Support for process-level isolation (each test thread runs in a separate process)
- Tool integrations (e.g. VS2010, TeamCity) will use the tool-specific profile if they exist (e.g. VS1010.srprofile)
- Allow wildcard filtering (*) for testpath filter, e.g. "testpath:Feature:*interface*"
- Adaptive test scheduler is not blocking until the test statistics are received from the server but start working on tests (in random order)

Bug fixes:
- Tests might be skipped when using parallel execution and test thread affinity
- Invalid test thread affinity configuration causes skipped tests
- When the unit test provider is configured to SpecRun+NUnit or SpecRun+MsTest, the Gherkin steps are not displayed properly in the report
- SpecRun+MsTest specflow unit test provider needs additional listener configuration for proper report output
- Failing tests might not reported in TeamCity
- Tests might not be scheduled properly for multuple threads when affinity is specified

1.1.0 - 2012-08-06

New features:
- Support for SpecFlow 1.9.0
- Easier setup through SpecFlow plugin infrastructure (no assembly copy is required):
  <specFlow>
    <unitTestProvider name="SpecRun" />
    <plugins>
      <add name="SpecRun" />
    </plugins>
  </specFlow>
- Easier configuration for executing the tests both with SpecRun and MsTest/NUnit: 
  use use SpecRun+NUnit or SpecRun+MsTest unit test provider name:
  <specFlow>
    <unitTestProvider name="SpecRun+NUnit" />
    <plugins>
      <add name="SpecRun" />
    </plugins>
  </specFlow>

Bug fixes:
- License is checked during registration
- System.Web.Razor assembly is missing from the NuGet package


1.0.0 - 2012/05/31

New features:
- Licensing: to use SpecRun in commercial projects, you have to purchase seat 
  licenses for each team member (not for the build server). 
  See more details at http://www.specrun.com.
- Evaluation mode: SpecRun can be used for evaluation without a license. In 
  this case the execution of the entire test suite is delayed by a few seconds 
  and an evaluation message is displayed.
- Feature and scenario description is included in the report
- Support for running NUnit tests. See NUnitSupport.txt for details.

Bug fixes:
- Tests cannot be executed from Visual Studio if the feature or scenario title contains parenthesis


0.14.0 - 2012/04/20

- Extended beta expiration until 30/05/2012

New features:
- Recognize file references in test output (starting with file://) and 
  converting them to relative links in the report.
- Support for STA/MTA apartment state through the execution settings of the 
  profile: <Execution apartmentState="STA" />

Bug fixes:
- Better control for IIS express (default changed to useShellExecute=false, 
  providing faster automation)
- The current directory is set to the base folder
- File logger creates the directory for the expected log file
- Report generator creates the directory for the expected report file
- Output discarded if tests are executed through an other test runner (e.g. R#)
- Report link is broken in Visual Studio if path contains space
- Generated testrun.cmd does not work on 32-bit machines


0.13.0 - 2012/01/23

- Extended beta expiration until 30/04/2012


0.12.0 - 2011/11/25

Bug fixes:
- TeamCity: skipped tests are reported as ignored
- TeamCity: better handling of special quotes in scenario titles
- TeamCity: report test steps and trace for failing tests
- Report: success rate is calculated improperly when there were skipped or 
  ignored tests
- Report: javascript error for empty tests


0.11.0 - 2011/10/26

New features:
- Updated for SpecFlow 1.8.1

Bug fixes:
- runtests.cmd does not work on x86 machines
- cancelling execution hangs
- console tracer fails with System.ArgumentOutOfRangeException


0.10.0 - 2011/10/11

Bug fixes:
- Performance problem when running many small tests
- Tagged examples may not generated properly
- NUnit/MsTest compatibility mode does not support categories and ignore
