   M S B A M L   `   `   `  ����U  QAcademyExamination_Affiong, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:AcademyExamination_Affiong.Views AcademyExamination_Affiong.Views  5   	   G(clr-namespace:AcademyExamination_AffiongAcademyExamination_Affiong  5   	   +    %AcademyExamination_Affiong.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:AcademyExamination_Affiong.Views     5   	   8loc(clr-namespace:AcademyExamination_Affiong     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   /   )AcademyExamination_Affiong.Views.TreeView  -   5          Name$ treeview��5   9   
�������$��1��6,   $
��Left=�6K   $	��300��6f   �� 5   
   $��2��6   .+�5      �� $��50��6    � ToolTip$ Import XML File��6    
���������6M   �� *Browse+.��5      �� $��/Images/import.png��6   5      d� 5      $ 
Connect To��6   $��50��60   $��0,5,0,0q�6;   
���������6L   �� *	Connected+.��5      �� $��/Images/connect.png��6   5      d� 5      $��50��6   $ Toggle��6&   $��0,5,0,0q�67   
���������6H   �� *
ToggleOn+.��5      �� $��/Images/toggle.png��6   5      �� 5      $��50��6   $ Write To XML��6    $��0,5,0,0q�67   
���������6[   �� *	SaveToXml+.��5      �� $��/Images/xml.png��6   5      �� 5       $ Save To Database��6   $��50��60   $��0,5,0,0q�6;   
�������.��5!      �� $��/Images/black.png��6   5"      5#      �� 5$   
   $��1q�6   
���   �$��1��69   $��1��6F   ._�5%      �� -   5         ��Name$ canvasContent��5%       J� 	AllowDrop . 65   5&      5'      5(      