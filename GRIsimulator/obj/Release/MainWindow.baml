   M S B A M L   `   `   `  ���� G  CGRIsimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GRIsimulatorGRIsimulator      GRIsimulator.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:GRIsimulator       � Title$  
MainWindow��$	��600��$
��1080��.��]� .+�o� -    o�Name$
 menu��$	��Top=�.@�m� $��_File��.@�m� -   $
��_New��m� -   $��_Open��m� -   $��_Save As��m� -   $��_Export��m� -   $��_Close��m� $��_Options��.@�m� $��_Not implemented��{�.  �  � ColumnDefinitions �� $	��200 ��� $��5 ��� .+��� $��0��$
��Auto=�$
��Auto=�.���� -    ��Name$ 
tree_panel���� $��1��$��5��$��Stretch=�]� $��2��.+�� $��3��$��RightToLeft=�$��Bottom=����	#FFF0F0F0$��40��.+��� -    ��Name$ save_all��$��Save All���� -	    ��Name$ 	test_disp��   textbox_style1#��[  $��20��$	��500��{�.  " �� VerticalScrollBarVisibility$
 Auto=��  � RowDefinitions �� $	��100 ��� $��5 ��� $��* �.+��� $��0��$
��Auto=�$��Stretch=�.���� -
   $ 
info_panel��.+�   GRIsimulator.Text1  -     Name$ 	info_text��	 �� TextWrapping$
	 Wrap=��� $��1��$��5��$��Stretch=��� $��2��$��Stretch=�$
��Auto=�.���� -   $ 
data_panel��$��Stretch=�.+�  -   $ title��$
	 Wrap=�]� -   
 ]�Name$
 edit_bar��.+�c� $	��Top=�.@��� -   $��btnBold��$ ��EditingCommands.ToggleBold��.���� $��lib\bold.png��$��16��$��16���� -   $��	btnItalic��$"��EditingCommands.ToggleItalic��.���� $��lib\italic.png��$��16��$��16���� -   $��btnUnderline��$%��EditingCommands.ToggleUnderline��.���� $��lib\underline.png��$��16��$��16���� �� -   $��	btnBullet��$#��EditingCommands.ToggleBullets��.���� $��lib\bullets.png��$��16��$��16���� �� -    ��Name$ richtextbox1�� �� AcceptsReturn . $
��Auto��$	��100��