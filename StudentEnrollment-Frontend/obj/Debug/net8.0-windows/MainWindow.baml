   M S B A M L   `   `   `  ����U  QStudentEnrollment-Frontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:StudentEnrollment_FrontendStudentEnrollment_Frontend  5   	   [2clr-namespace:StudentEnrollment_Frontend.ViewModel$StudentEnrollment_Frontend.ViewModel  6@   +    %StudentEnrollment_Frontend.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:StudentEnrollment_Frontend     5   	   H	ViewModel2clr-namespace:StudentEnrollment_Frontend.ViewModel     6@     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	      >   8StudentEnrollment_Frontend.ViewModel.MainWindowViewModel   VM   BooleanToVisibilityConverter��%:   &	        &	        5
   
   6(   �� 5   
   6'   5      .��5      � -   5         �Name$ MainGrid��5      $��Center=�5       � DataContext 5      ��  �� Source# [   � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��4* �6   .+�5   
   �� -   5         ��Name$ StackPanelGetPost��5       �� Orientation$ 
Horizontal=�5   	   $��Center=�5   	   $��0 10 0 0q�5   	   .+�5      �� -   5         ��Name$ 	ButtonGet��5      $��20��5      $	��120��5      $	��GET��5      ��5      �� *GetButtonClicked+5      �� 5      -   5        $ 
ButtonPost��5      $��10 0 0 0q�5!      $��20��5"      $	��120��5#      $��Register Course��5$      $��Bottom=�5%      ��5       �� *ShowRegistrationForm+5%      5&      � 5'   
   -   5        $ GridCourseDetails��5'      $��1��5)      y�5(      �� *
IsLoadData+	 �� 	Converter#	 [  5*      �� 5+      $
��Auto �6    �� 5,      $��* �6    �� 5-      $��* �6    .+�5/      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 DataGridCourse��5/         AutoGenerateColumns$ False��52         AlternatingRowBackground
 ��ح�
�������$��5q�55      
�������$��0 10 0 0q�57         RowBackground
 �����$	��310��59      ��50      �� *	Courses+ �� SelectedItem 51      �� *SelectedCourse+   Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      -   5        
ColumnName��,  &System.Windows.Controls.DataGridColumn   Header$
 Name��5<   !   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5=   !   �� *Name+  5>      -   5        ColumnSubject��$ Subject��5?   !    5@   !   �� *	Subject+  5A      -	   5        ColumnStartDate��$ 
Start Date��5B   !    5C   !   �� *	StartDate+  5D      -
   5        ColumnEndDate��$ End Date��5E   !    5F   !   �� *	EndDate+  5G      -   5        
ColumnFees��$
 Fees��5H   !    5I   !   �� *Fees+  5J      -   5        ColumnLocation��$ Location��5K   !    5L   !   �� *
Location+  5M      -   5        ColumnContactPerson��$ Contact Person��5N   !    5O   !   �� *ContactPerson+5Q      �� 5R      -   5        $ StackPanlePutDelete��5R      $��Center=�5S      $��0 10 0 0q�5T      $ 
Horizontal=�5U      $��1��5V      .+�5W      �� -   5        $ 	ButtonPut��5W      $��20��5Z      $	��120��5[      $��Update��5\      ��5X      �� *PutButtonClicked+��5Y      �� *SelectedCourse+5\      �� 5]      -   5        $ ButtonDelete��5]      $��10 0 0 0q�5`      $��20��5a      $	��120��5b      $��Delete��5c      ��5^      �� *DeleteButtonClicked+��5_      �� *SelectedCourse+5c      5d      �� 5e      -   5         ��Name$ TextBlockResponse��5e      $��Center=�5g      $��20 8 0 0q�5h      $��2��5i      ��5f      �� *ResponseMessage+5i      5j      � 5m   
   -   5        $ GridCreateNewEmployee��5m      $��2��5o   	   y�5n   	   �� *
IsShowForm+#	 [  5p      �� 5q      $
��Auto �6    �� 5r      $
��Auto �6    �� 5s      $
��Auto �6    �� 5t      $
��Auto �6    �� 5u      $
��Auto �6    �� 5v      $
��Auto �6    �� 5w      $
��Auto �6    �� 5x      $
��Auto �6    �� 5y      $
��Auto �6    �� 5z      $��5* �6     � ColumnDefinitions 5|      �� 5}      $
��Auto �6#   �� 5~      $
��Auto �6#   .+�5�      �� -   5         ��Name$ LabelCourseName��5�      $��Course Name:��5�      $��0 10 0 0q�5�      �� 5�      -   5        $ LabelDescription��5�      $��Description:��5�      $��1��5�      �� 5�      -   5        $ LabelStartDate��5�      $��Start Date:��5�      $��2��5�      �� 5�      -   5        $ LabelEndDate��5�      $��	End Date:��5�      $��3��5�      �� 5�      -   5        $ 	LabelFees��5�      $��Fees:��5�      $��4��5�      �� 5�      -   5        $ LabelSubject��5�      $��Subject:��5�      $��5��5�      �� 5�      -   5        $ LabelLocation��5�      $��	Location:��5�      $��6��5�      �� 5�      -   5        $ LabelBranchAddress��5�      $��Branch Address:��5�      $��7��5�      �� 5�      -   5        $ LabelContactPerson��5�      $��Contact Person:��5�      $��8��5�      �� 5�      -   5         ��Name$ TextBoxCourseName��5�      $��20��5�      $	��150��5�      $��1��5�      ��5�      �� *Name+5�      �� 5�      -   5        $ TextBoxDescription��5�      $��20��5�      $	��150��5�      $��1��5�      $��1��5�      ��5�      �� *Description+5�      �� 5�      -   5        $ TextBoxStartDate��5�      $��20��5�      $	��150��5�      $��2��5�      $��1��5�      ��5�      �� *	StartDate+5�      �� 5�      -   5        $ TextBoxEndDate��5�      $��20��5�      $	��150��5�      $��1��5�      $��3��5�      ��5�      �� *	EndDate+5�      �� 5�      -    5        $ TextBoxFees��5�      $��20��5�      $	��150��5�      $��4��5�      $��1��5�      ��5�      �� *Fees+5�      �� 5�      -!   5        $ TextBoxSubject��5�      $��20��5�      $	��150��5�      $��5��5�      $��1��5�      ��5�      �� *	Subject+5�      �� 5�      -"   5        $ TextBoxLocation��5�      $��20��5�      $	��150��5�      $��6��5�      $��1��5�      ��5�      �� *
Location+5�      �� 5�      -#   5        $ TextBoxBranchAddress��5�      $��20��5�      $	��150��5�      $��7��5�      $��1��5�      ��5�      �� *BranchAddress+5�      �� 5�      -$   5        $ TextBoxContactPerson��5�      $��20��5�      $	��150��5�      $��8��5�      $��1��5�      ��5�      �� *ContactPerson+5�      �� 5�      -%   5        $ 	ButtonAdd��5�      $��20��5�      $	��100��5�      $
��POST��5�      $��Center=�5�      $��	20 10 0 0q�5�      $��9��5�      $��2��5�      ��5�      �� *PostButtonClicked+��5�      �� *	NewCourse+5�      �� 5�      -&   5        $ TextBlockMessage��5�      $��Center=�5�      $��20 8 0 0q�5�      $��10��5�      $��2��5�      ��5�      �� *ShowPostMessage+5�      5�      5�      5�      