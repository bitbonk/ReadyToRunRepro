# ReadyToRun .NET 8 regression bug reproduction demo

## Steps to reproduce

1. Clone this repo and run 

   `dotnet publish .\ReadyToRunRepro\ReadyToRunRepro.csproj  --configuration=Release -p:PublishReadyToRun=true --runtime win-x64 --self-contained`
   
   followed by 

   `.\ReadyToRunRepro\bin\Release\net7.0\win-x64\publish\ReadyToRunRepro.exe`

2. See that the worker service correctly starts and runs without errors
3. Change the target framework in `ReadyToRunRepro.csproj` to .NET 8: `<TargetFramework>net8.0</TargetFramework>`
4. Publish again with the same command as in 1.: 

   `dotnet publish .\ReadyToRunRepro\ReadyToRunRepro.csproj  --configuration=Release -p:PublishReadyToRun=true --runtime win-x64 --self-contained`
   
   and then start the published .NET 8 exe:

   `.\ReadyToRunRepro\bin\Release\net8.0\win-x64\publish\ReadyToRunRepro.exe`
5. The following exception occurs:

```
Unhandled exception. System.TypeLoadException: Return type in method 'ReadyToRunRepro.DataElementBase`1[TIdentifier].get_Id()' on type 'ReadyToRunRepro.DataElementBase`1[TIdentifier]' from assembly 'ReadyToRunRepro, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' is not compatible with base type method 'ReadyToRunRepro.DataElementBase.get_Id()'.
   at ReadyToRunRepro.Service..ctor()
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)
   at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite constructorCallSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitRootCache(ServiceCallSite callSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite constructorCallSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitRootCache(ServiceCallSite callSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitIEnumerable(IEnumerableCallSite enumerableCallSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitRootCache(ServiceCallSite callSite, RuntimeResolverContext context)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve(ServiceCallSite callSite, ServiceProviderEngineScope scope)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.CreateServiceAccessor(ServiceIdentifier serviceIdentifier)
   at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(ServiceIdentifier serviceIdentifier, ServiceProviderEngineScope serviceProviderEngineScope)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(Type serviceType)
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(IServiceProvider provider, Type serviceType)
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService[T](IServiceProvider provider)
   at Microsoft.Extensions.Hosting.Internal.Host.StartAsync(CancellationToken cancellationToken)
   at Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync(IHost host, CancellationToken token)
   at Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync(IHost host, CancellationToken token)
   at Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run(IHost host)
   at Program.<Main>$(String[] args) in C:\source\ReadyToRunRepro\ReadyToRunRepro\Program.cs:line 8
```

