   M S B A M L   `   `   `  ����G  CGRIsimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GRIsimulatorGRIsimulator  5   	       GRIsimulator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:GRIsimulator     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1080��6)   .��5
      ]� .+�5   
   o� -   5         o�Name$
 menu��5      $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� -   5        $
��_New��5      6)   m� 5      -   5        $��_Open��5      6*   m� 5      -   5        $��_Save As��5      6-   m� 5      -   5        $��_Export��5      6,   m� 5      -   5        $��_Close��5      6+   5      m� 5      $��_Options��6   .@�5      m� $��_Not implemented��6   {�.  65   5      5      � 5   
    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��5 �6#   �� 5      .+�5       �� $��0��6   $
��Auto=�6+   $
��Auto=�6P   .��5!      �� -   5         ��Name$ 
tree_panel��5!      5#      5$      �� 5&      $��1��6   $��5��6+   $��Stretch=�65   ]� 5(      $��2��6   .+�5*      � $��3��6   $��RightToLeft=�6)   $��Bottom=�6E   ���	#FFF0F0F0$��40��6t   .+�5+      �� -   5         ��Name$ save_all��5+      $��Save All��6?   �� 5-      -	   5         ��Name$ 	test_disp��5-         textbox_style1#��[  61   $��20��6Y   $	��500��6e   {�.  " �� VerticalScrollBarVisibility$
 Auto=�6�   6�   5.      � 5/       � RowDefinitions 50      �� 51      $	��100 �6(   �� 52      $��5 �6(   �� 53      $��* �6(   .+�56      �� $��0��6#   $
��Auto=�60   $��Stretch=�6S   .��57      �� -
   5        $ 
info_panel��57   %   .+�58         GRIsimulator.Text1  -   5          Name$ 	info_text��58   *   	 �� TextWrapping$
	 Wrap=�6=   6S   59      5:      �� 5<      $��1��6#   $��5��60   $��Stretch=�6;   �� 5>      $��2��6#   $��Stretch=�60   $
��Auto=�6L   .��5?      �� -   5        $ 
data_panel��5?   %   $��Stretch=�69   .+�5@        -   5        $ title��5@   *   $
	 Wrap=�69   6O   ]� 5A      -   5        
 ]�Name$
 edit_bar��5A   (   .+�5B   "   c� $	��Top=�6*   .@�5C   &   �� -   5        $��btnBold��5C   R   $ ��EditingCommands.ToggleBold��6-   .��5D   *   �� $��lib\bold.png��60   $��16��6F   $��16��6Q   5E   '   �� 5F   &   -   5        $��	btnItalic��5F   T   $"��EditingCommands.ToggleItalic��6-   .��5G   *   �� $��lib\italic.png��60   $��16��6H   $��16��6S   5H   '   �� 5I   &   -   5        $��btnUnderline��5I   W   $%��EditingCommands.ToggleUnderline��6-   .��5J   *   �� $��lib\underline.png��60   $��16��6K   $��16��6V   5K   '   �� 5L   &   �� 5M   &   -   5        $��	btnBullet��5M   U   $#��EditingCommands.ToggleBullets��6-   .��5N   *   �� $��lib\bullets.png��60   $��16��6I   $��16��6T   5O   '   �� 5P   &   5Q   #   5R      �� 5S      -   5         ��Name$ richtextbox1��5S   *    �� AcceptsReturn . $
��Auto��6U   $	��100��6c   5T      5U      5V      5W      5X      5Y      5Z      