# ModernUIWithCaliburnMicro
This project is designed to show how you can integrate Caliburn Micro with Modern UI giving your WPF applications a fresher look. 
Personally, I found it to be a bit of a challenge to integrate the two libraries together. I hope that others can use this application a starting point if they want to use these two libraries together.

## Libraries I Used
* [Caliburn Micro](https://caliburnmicro.com/)
* [Modern UI](https://github.com/firstfloorsoftware/mui)

## Navigation
Navigation needs three classes to work. If any of them are missing, chances are the application won’t work properly.
* Bootstrapper
* FrameNavigatorConductor
* ModernContentLoader

### Boostrapper
This is where the dependency injection happens. All of you viewmodels need to be registered here (see lines 23 - 49). 
You could bind them later in the application but that wouldn't be true dependency injection.

### FrameNavigatorConductor
This handles all the navigation events. You'll notice that all the casting uses 'as' rather than a straight forward cast. 
[This is to avoid InvalidCastExceptions.](https://stackoverflow.com/questions/132445/direct-casting-vs-as-operator)

### ModernContentLoader
This class allows caliburn micro to find Modern Ui models and views. Modern UI doesn't use a typical window, it uses it's own implementation (might be inherit the window class though). 
This allows for the combination of the model and view to work correctly.

## Pitfalls I Encountered

### Everything has to be Named Perfectly
Everything has to be named perfectly. That means down to the namespace. 
When Caliburn Micro is looking for HomeView's viewmodel it's looking for HomeViewModel.cs in MyAppNameSpace.ViewModels in the ViewModel folder. 
You can change this behavior, of course, but this is a pitfall that got me a ton of times.

### How to Debug
If you run into a composition issue, I recommend downloading the [caliburn micro source code](https://github.com/Caliburn-Micro/Caliburn.Micro) and including it directly into your application.
This will allow you to see what events, views, and view models caliburn is trying to find (or not even looking for).