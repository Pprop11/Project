   M S B A M L   `   `   `  ����O  KReal 3D Model Viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Real_3D_Model_ViewerReal_3D_Model_Viewer  5   	   %    Real_3D_Model_Viewer.MainWindow   5   	   ` \HelixToolkit.Wpf.SharpDX, Version=2.12.0.0, Culture=neutral, PublicKeyToken=52aa3500039caf0d-hx$http://helix-toolkit.org/wpf/SharpDX  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Real_3D_Model_Viewer     5   	     � Title$  3D Model Viewer��5	   	   $	��600��6!   $	��900��6.    � 
ResizeMode$ NoResize=�6:   .��5      � $��10,10,13.6,6.4q�6    J� RenderTransformOrigin$ 0.113,0.781&�6#   .+�5   
   *  $HelixToolkit.Wpf.SharpDX.Viewport3DX  $��10,99,10,10q�6]      Camera 6   �� *Camera+   EffectsManager 63   �� *EffectsManager+   Items. 5      1  +HelixToolkit.Wpf.SharpDX.DirectionalLight3D  &   HelixToolkit.Wpf.SharpDX.Light3D   Color$ #D6D6D6��6O      	Direction 6$   �� *Camera.LookDirection+6O   1  +HelixToolkit.Wpf.SharpDX.Element3DPresenter  5         Content 6$   �� *
GroupModel+	 J� InputBindings	 5      �� 5      

 �� Key$
 B��6    �� Command$" hx:ViewportCommands.BackView��6%   �� 5      $
 F��6   $# hx:ViewportCommands.FrontView��6%   �� 5      $
 T��6   $! hx:ViewportCommands.TopView��6%   �� 5      $
 D��6   $$ hx:ViewportCommands.BottomView��6%   �� 5      $
 L��6   $" hx:ViewportCommands.LeftView��6%   �� 5      $
 R��6   $# hx:ViewportCommands.RightView��6%   �� 5      $% hx:ViewportCommands.ZoomExtents��6    �� Gesture$ 	Control+E��6G   d� 5      $  hx:ViewportCommands.Rotate��6    d� Gesture$ 
RightClicka�6D   d� 5      $ hx:ViewportCommands.Zoom��6   $ MiddleClicka�6B   d� 5      $ hx:ViewportCommands.Pan��6   $ 	LeftClicka�6A   5      �� 5   
   -   5         ��Name$ OpenModel_Button��5      $%��Загрузить модель��6+   $
��Left=�6F   $��	10,29,0,0q�6a   $	��Top=�6t   $	��140��6�   $��50��6�   $��Times New Roman)�6�   $��18(�6�   �� 5   
   $��340,44,342,480q�6   $��Times New Roman)�6Q   $��18(�6n    d� 	IsChecked 6+   �� *EnableAnimation+.��6}   #!Включить анимацию6�   �� 5   
    �� DisplayMemberPath$
 Name��6a   $��554,42,76,480q�6z   $��Times New Roman)�6�   $��18(�6�   ��6   �� *
Animations+ �� SelectedItem 66   �� *SelectedAnimation+6�   �� 5   
   -   5        $ ClearScene_Button��5      $!��Очистить сцену��6,   $
��Left=�6E   $��
173,29,0,0q�6`   $	��Top=�6t   $	��140��6�   $��50��6�   $��Times New Roman)�6�   $��18(�6�   �� 5    
   $#��Список анимаций��6   $
��Left=�6*   $��	554,7,0,0q�6E   $	��Top=�6X   {�.  $	��184��6�   $��Times New Roman)�6�   $��18(�6�   �� 5!   
   -   5        $ QuestButton��5!      $��?��6&   $
��Left=�62   $��	833,7,0,0q�6M   $	��Top=�6`   $��27��6x   $��Times New Roman)�6�   $��18(�6�   $
��Bold"�6�   $��30��6�   6�   5"      5#      