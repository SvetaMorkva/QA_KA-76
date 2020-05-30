Imports TechTalk.SpecFlow
Imports TechTalk.SpecRun
Imports System
Imports System.Reflection

Public NotInheritable Class PROJECT_ROOT_NAMESPACE_SpecFlowPlusRunnerAssemblyHooks

    <AssemblyInitialize>
    Public Shared Sub AssemblyInitialize()
        Dim currentAssembly As Assembly = GetType(PROJECT_ROOT_NAMESPACE_SpecFlowPlusRunnerAssemblyHooks).Assembly

        TestRunnerManager.OnTestRunStart(currentAssembly)
    End Sub

    <AssemblyCleanup>
    Public Shared Sub AssemblyCleanup()
        Dim currentAssembly As Assembly = GetType(PROJECT_ROOT_NAMESPACE_SpecFlowPlusRunnerAssemblyHooks).Assembly

        TestRunnerManager.OnTestRunEnd(currentAssembly)
    End Sub

End Class
