   M S B A M L   `   `   `  ����H  DCourseProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CourseProject.ViewsCourseProject.Views  5   	   &     CourseProject.Views.RatingWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:CourseProject.Views     5   	     � Title$  RatingWindow��5   	   $	��450��6   $	��400��6+    � 	Resources 5	         gradientStyleBackground �� 
StartPoint �� EndPoint � Color � Offset��%�   &	        �� 5
   
   $ 0.5,0&�6>   $
 1, 1&�6Q   .��5      � $
 Pink��6   $ 0Q�6(   � 5      $ 
LightCoral��6   $ 1Q�6.   5      5      .��5      � .+�5   
   �� #��[  62   ��6   �� *	Players+��5      �� 5      .R�5      �� $��5q�6   $	��300��6(    �� CornerRadius$ 20��64   
�������._�5      �� $��15q�6%   .+�5      ��  �� Orientation$ 
Horizontal=�6)   .+�5   "   �� $��20(�6,   
���� ��$��
Nickname: ��6N   �� 5   "   $��20(�6,   ��6:   ��  �� Path$ Login�5      �� 5      $ 
Horizontal=�6)   .+�5   "   �� $��18(�6,   
����  �$��Rank: ��6P   �� 5   "   $��18(�6,   ��6:   �� $
 Rank�5      �� 5      $ 
Horizontal=�6)   .+�5   "   �� $��16(�6,   ���#383838$��Completed levels: ��6O   �� 5   "   $��16(�6,   ��6:   �� $ CompletedLevels�5       �� 5!      $ 
Horizontal=�6)   .+�5"   "   �� $��16(�6,   ���#383838$��Guessed words: ��6O   �� 5#   "   $��16(�6,   ��6:   �� $ GuessedWords�5$      5%      5&      5'      5)      5*      5+      