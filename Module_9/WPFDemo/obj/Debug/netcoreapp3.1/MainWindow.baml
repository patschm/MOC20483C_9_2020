   M S B A M L   `   `   `  ����B  >WPFDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPFDemoWPFDemo  5   	   7 clr-namespace:WPFDemo.ViewModelsWPFDemo.ViewModels  5   	       WPFDemo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WPFDemo     5   	   /my clr-namespace:WPFDemo.ViewModels     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � 	Resources 5
      (   "WPFDemo.ViewModels.PersonViewModel   p1
   Age   Name��%;   &	          5   
   $ 42��6(   $
 Jane��61   6?   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      $	��100 �6   6+   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $	��200 �6   6-   �� 5      $��* �6   6+   .+�5   
   �� $��0��67   $��2��6G   ��6   ��  �� Path$ People���5      �� 5      .R�5      �� .+�5      �� 
���  ����65   �� $
 Name�6R   �� 5      $��28(�6$   ��62   �� $	 Age�6N   5      5      5!      �� 5#   
   -   5         ��Name$
 txt1��5#      $��1��6    $��0��60   $��20q�6=   ��6I   �� $ Person.Name�6m   �� 5$   
   $��1��6   $��1��6"   $��30q�6/   .��6;   OK6?   �� 5%   
   $��0��6   $��0��6"   ��6/   �� $ Person.Name�6W   �� 5&   
   $��1��6   $��0��6"   .+�5'      �� .��6   	Stakker6   �� 5(      .��6   	Stakker6   5)      �� 5*   
   -   5        $��160, 40q�5*      $��1��6"   $��2��62   ��5+      r� 5,       r� Source$ Wildlife.wmv?�6   67   z�5.      �� 5/      -   5        rot��	 �� CenterX$		 200Q�5/   /   
 �� CenterY$	
 100Q�6=    �� Angle$ 0Q�6K   6W    � Triggers 51      :� 52       :� RoutedEvent$ Button.Click��6   .[�53      �� .��54      �� .��55      W�  �� 
TargetName$	 rot��6.    �� TargetProperty$ Angle�56   .    W� From 057   .   	 W� To 36058   .    g� Duration$ 0:0:0:5D�59   .    g� RepeatBehavior$ Forever��5:   .   5;   1   5<      5=      5>      5@      5A      5B      