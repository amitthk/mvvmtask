MvvmTask

This is the very basic  .Net WPF+WCF todo application written in basic MVVM pattern. Basically a reusable startup project.


The WPF application self hosts the WCF service. The application then uses a client to consume this WCF service.


The steps are simple. I will try to add blog for it that'd explain it better. Basic steps are:-


# 1. create a wpf project in Visual Studio (lots of quickstarts available online)
# 2. Create these folders - Views, ViewModels, Common 
	- (viewmodels store our viewmodels, common stores common files, View stores views)

# 3. Move MainWindow to Views folder.
# 4. In App.xaml point the startup uri to correct place  (StartupUri=Views/MainWindow.xaml)
# 5. Add a class ViewModels\MainWindowViewmodel, (we are going to bind our MainWindow.xaml to it)
# 6. Add Common\ViewModelLocator. 
	## This is our injector/mapper of Views=>ViewModels. 
	## Expose public property type MainWindowViewModel.
# 7. In App.xaml add the ResourceDictionary  
        <ResourceDictionary>
            <vm:ViewModelLocator x:Shared="False"  x:Key="Locator" xmlns:vm="clr-namespace:MvvmTask.Common" />
        </ResourceDictionary>
        
# 8. Bind the Views/MainWindow.xaml to ViewModels\MainWindowViewModel
	## In Views/MainWindow.xaml  bind the property DataContext="{Binding MainWindowViewModel, Source={StaticResource Locator}}"

# 9. Add Common\Bootstrapper. Add start and exit bootstrap routines to this. Call this bootstrapper in App.Xaml.cs (OnStartup and OnExit)
# 10. Add the ClassLibrary project MvvmTask.Service. (We will add our WCF service implementation here. I wouldn't go to lot of detail there are number of tutorials available online.)
	## Example here http://www.codeproject.com/Articles/650869/Creating-a-Self-Hosted-WCF-Service
# 11. Add the DataContract class to MvvmTask.Service (Todo.cs with its properties. Decorate them with [DataContract], [DataMember] etc.)
# 12. Add the ServiceContract and its implementation. (ITodoService and TodoService resp)
# 13. Add the service bindings to our main Wpf App.config
# 14. In Common\Bootstrap create a Service host. Open() the host on start and Close() it on Exit of application.
# 15. Create the Service using Visual Studio command prompt> svcutil utility.
# 16. Update the client config in App.config and Copy over the generated TodoService class into \ServiceClient directory.
# 17. Add \Common\RelayCommand. Add the code for Crud operations using the above client in MainWindowViewModel.