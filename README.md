This repository has a prototype of a Unity file importer tool

You can find the code in the "Assets/Editor" directory

Currently it only imports .png files into your project, but further modifications are possible to support more file formats

***How To Use The Tool***
1. Navigate to the "Tools" menu button
2. Press on Importer. This will open the tools main window
3. Press the "Select" button to select a .png file you want to import
4. Set if it is animated or not (Spine usage)
5. If it is not animated, check the pivot location (Top Left or Center)
6. Press the "Import" button. Animated assets get placed in the AnimatedObjects folder, non-animated - StaticObjects folder. If they do not exist, they get created for you
