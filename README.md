# Overview
**wpf-easy-acheivements** as a WPF Library that allows you to quickly and easily implement a basic acheivement system for games or other applications.  The features are currently very limited but will be expanded if there seems to be intrest.

# What's included at the moment?
As mentioned above, the current functionality is limited however it should be enough to be usable:
* Basic Acheivement System - System that will store, track the progress and notify about acheivement changes
* Basic Acheivement UI Control - A very basic UI control that can be used to display acheivements
* Ability to implement with your UI Systems - if you don't like the Basic Acheivement UI then you are able to integrate with your own UI ([Example](http://test.com))


# Getting Started
Getting started with **wpf-easy-acheivements** is very simple, the easiest way is to grab the [Latest DLL](http://test.com) and then reference that in your project.  Once you have a reference to the DLL you are then able to start creating and tracking acheivements.

```csharp
        public MainWindow()
        {
            InitializeComponent();
            
            //Create the new acheivement
            BasicAcheivement acheivement = new BasicAcheivement("This is a test acheivement", "Thank you for checking out this code :)", 
            
            //Add the acheivement to the system
            WPFEasyAcheivements.AcheivementSystem.AddAcheivement(acheivement);
            
            //Increment the progress
            acheivement.IncrementProgress();
        }
```
If you'd like to use the provided Acheivement UI simply add the control to your ui and that's it.

```xaml
<Window x:Class="Example1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:controls="clr-namespace:WPFEasyAcheivements.Controls;assembly=wpfeasyacheivements"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <controls:AcheivementDialog Grid.Row="1"/>
    </Grid>
</Window>

```

# Examples
I've provided some examples that might help answer any questions that you have:
* [UsingIncludedDialog](http://test.com) - Shows you how to use the built in dialog
* [CreatingACustomDialog](http://tets.com) - Shows you how to integrate into your own UI systems