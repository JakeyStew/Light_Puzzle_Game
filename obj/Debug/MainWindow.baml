   M S B A M L   `   `   `  ����K  GLightsPuzzleGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LightsPuzzleGameLightsPuzzleGame  5   	   !    LightsPuzzleGame.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:LightsPuzzleGame     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$' !Jake Stewart - Lights Puzzle Game��5	   	   $	��500��63   $	��500��6@    � 	Resources 5         ButtonRoundedCorners �� 
TargetType �� CornerRadius J� SnapsToDevicePixels ��Name �� ContentStringFormat �� ContentStringFormat	 �� Triggers
 P� Property P� Value �� 
TargetName �� Value �� Property��%u  &	        �� 5   
   " ��67   .R�5      �� $��border��6   $ 5��6#   
��� d �$	��1.5q�6L   #��z��6b    . ._�5      �� $ contentPresenter��6#   #��z��6=   #��z��6q   # z 6�   |�.  #��z��6�   #��z��6&  ��. # z 6d  #��z��6�  5      	 5      P� 5      
 �@��IsDefaulted . . �5      �� $ border��64   # � ��6H    � ��5      P� 5      
 �@J�IsMouseOver . . �5      �� $ border��63    � �� �	#FFBEE6FD6G   �� 5      $ border��64    � �� �	#FF3C7FB16H   5      P� 5      
 � �� . . �5      �� $ border��63    � �� �	#FFC4E5F66G   �� 5      $ border��64    � �� �	#FF2C628B6H   5      P� 5      
 �@d�	IsChecked$
 TrueY�6<   . �5      �� $ border��63    � �� �	#FFBCDDEE6G   �� 5      $ border��64    � �� �	#FF245A836H   5       P� 5!      
 � {� .  . �5"      �� $ border��63    � �� �	#FFF4F4F46G   �� 5#      $ border��64    � �� �	#FFADB2B56H   �� 5$       � �� �	#FF83838363   5%      5'      5(      .��5*      � -   5         �Name$ 	Container��5*       � ColumnDefinitions 5+   
   �� 5,      $��* �6   �� 5-      $��* �6   �� 5.      $��* �6   �� 5/      $��* �6   �� 50      $��* �6    � RowDefinitions 52   
   �� 53      $��* �6   �� 54      $��* �6   �� 55      $��* �6   �� 56      $��* �6   �� 57      $��* �6   .+�5=   
   �� -   5         ��Name$ 
button_0_0��5=      $��0��6%   $��0��65   $��1��6B   #���   6c   �� 5>   
   -   5        $ 
button_1_0��5>      $��1��6%   $��0��65   $��2��6B   #���   6c   �� 5?   
   -   5        $ 
button_2_0��5?      $��2��6%   $��0��65   $��3��6B   #���   6c   �� 5@   
   -   5        $ 
button_3_0��5@      $��3��6%   $��0��65   $��4��6B   #���   6c   �� 5A   
   -   5        $ 
button_4_0��5A      $��4��6%   $��0��65   $��5��6B   #���   6c   �� 5D   
   -   5        $ 
button_0_1��5D      $��0��6%   $��1��65   $��6��6B   #���   6c   �� 5E   
   -   5        $ 
button_1_1��5E      $��1��6%   $��1��65   $��7��6B   #���   6c   �� 5F   
   -	   5        $ 
button_2_1��5F      $��2��6%   $��1��65   $��8��6B   #���   6c   �� 5G   
   -
   5        $ 
button_3_1��5G      $��3��6%   $��1��65   $��9��6B   #���   6c   �� 5H   
   -   5        $ 
button_4_1��5H      $��4��6%   $��1��65   $��10��6B   #���   6d   �� 5K   
   -   5        $ 
button_0_2��5K      $��0��6%   $��2��65   $��11��6B   #���   6d   �� 5L   
   -   5        $ 
button_1_2��5L      $��1��6%   $��2��65   $��12��6B   #���   6d   �� 5M   
   -   5        $ 
button_2_2��5M      $��2��6%   $��2��65   $��13��6B   #���   6d   �� 5N   
   -   5        $ 
button_3_2��5N      $��3��6%   $��2��65   $��14��6B   #���   6d   �� 5O   
   -   5        $ 
button_4_2��5O      $��4��6%   $��2��65   $��15��6B   #���   6d   �� 5R   
   -   5        $ 
button_0_3��5R      $��0��6%   $��3��65   $��16��6B   #���   6d   �� 5S   
   -   5        $ 
button_1_3��5S      $��1��6%   $��3��65   $��17��6B   #���   6d   �� 5T   
   -   5        $ 
button_2_3��5T      $��2��6%   $��3��65   $��18��6B   #���   6d   �� 5U   
   -   5        $ 
button_3_3��5U      $��3��6%   $��3��65   $��19��6B   #���   6d   �� 5V   
   -   5        $ 
button_4_3��5V      $��4��6%   $��3��65   $��20��6B   #���   6d   �� 5Y   
   -   5        $ 
button_0_4��5Y      $��0��6%   $��4��65   $��21��6B   #���   6d   �� 5Z   
   -   5        $ 
button_1_4��5Z      $��1��6%   $��4��65   $��22��6B   #���   6d   �� 5[   
   -   5        $ 
button_2_4��5[      $��2��6%   $��4��65   $��23��6B   #���   6d   �� 5\   
   -   5        $ 
button_3_4��5\      $��3��6%   $��4��65   $��24��6B   #���   6d   �� 5]   
   -   5        $ 
button_4_4��5]      $��4��6%   $��4��65   $��25��6B   #���   6d   5_      5`      