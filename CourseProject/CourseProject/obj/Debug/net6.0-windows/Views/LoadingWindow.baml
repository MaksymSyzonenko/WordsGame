   M S B A M L   `   `   `  ����H  DCourseProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CourseProject.ViewsCourseProject.Views  5   	   '    !CourseProject.Views.LoadingWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CourseProject.Views     5   	     � Title$  LoadingWindow��5   	   $	��180��6   $	��400��6,    � 	Resources 5	         gradientStyle1 �� 
StartPoint �� EndPoint � Color � Offset��%�   &	        �� 5
   
   $	 0,0&�65   $
 1, 1&�6F   .��5      � $ LightSeaGreen��6   $ 0Q�61   � 5      $ 
Aquamarine��6   $	 0.5Q�6.   � 5      $ GreenYellow��6   $ 1Q�6/   5      5      .��5      � #��[  6   .+�5   
   �� $��35q�6    K� ZIndex$ 2��6!   .+�5      �� $��17(�6   $��Bahnschrift Light)�6"   $*��$Завантаження слів...��6A   $��Center=�6`   �� 5      $��1q�6   
�������$��25��6@   $	��240��6L   ._�5      � -   5        $��progressBar��5   9   
����� �$��Center=�6L   $��25��6i   $	��240��6u   5      5      �� 5   
   $��30q�6   
������� �� CornerRadius$ 25��60    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 40Q�6#   
   Color$

 Gray��63      ShadowDepth$ 0Q�6@   5      5      5      