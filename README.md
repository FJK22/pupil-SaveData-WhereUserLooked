# pupil-SaveData-WhereUserLooked
A script that allows to save data where the user has looked using Pupil in a Unity Application

Once you downloaded the latest release of Unity package from pupil (https://github.com/pupil-labs/hmd-eyes/releases), you can go to Assets->Plugins->Pupil->Prefabs folder and get the gaze tracker prefab and include it in your Unity scene project. You can then follow the tutorial on: https://youtu.be/77c013LrMrs You will need to create colliders in the game objects that you are interested to see if the user will look at those and assign a tag to them. Then add the script OnCollisionEye.cs to your project. You will then be able to collect data from where the user has looked.
