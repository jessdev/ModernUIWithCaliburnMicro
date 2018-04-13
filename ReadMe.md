# ModernUIWithCaliburnMicro
This project is designed to show how you can integrate Caliburn Micro with Modern UI giving your WPF applcations a fresher look. 
Personally, I found it to be a bit of a challange to integrate the two libraries together. I hope that others can use this applicationas a starting point if they want to use these two libraries together.

## Libraries I used
* [Caliburn Micro](https://caliburnmicro.com/)
* [Modern UI](https://github.com/firstfloorsoftware/mui)

## Pitfalls I encountered

### Everything has to named perfectly
Everything has to be named perfectly. That means down to the namespace. 
When Caliburn Micro is looking for HomeView's viewmodel it's looking for HomeViewModel.cs in MyAppNameSpace.ViewModels in the ViewModel folder. 
You can change this behavior, of course, but this is a pitfall that got me a ton of times.
