   M S B A M L   `   `   `  ����M  IBCS426Homework5WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:BCS426Homework5WPFBCS426Homework5WPF  5   	   #    BCS426Homework5WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:BCS426Homework5WPF     5   	   -   5          �Name$  window��5   	    � Title$&  Course Work GUI - Samantha Smith��5	   	   $	��450��62   $	��800��6?   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��178* �6   �� 5      $
��219* �6   .+�5   
   �� -   5         ��Name$ listBoxSubmission��5      $
��Left=�6-   $��
10,64,0,10q�6H   $	��198��6\   6h   �� 5   
   $��Submissions��6   $
��Left=�6&   $��	10,33,0,0q�6A   $	��Top=�6T   �� 5   
   $��Assignment Name��6   $
��Left=�6*   $��
237,64,0,0q�6E   $	��Top=�6Y   �� 5   
   $��Category Name��6   $
��Left=�6(   $��
237,96,0,0q�6C   $	��Top=�6W   �� 5   
   $��Grade��6   $
��Left=�6    $��237,127,0,0q�6;   $	��Top=�6P   �� 5   
   -   5         ��Name$ textBoxAssignmentName��5      $��23��61   $��9.4,67,9.6,0q�6=    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g    �� 
IsReadOnly .  ^� ToolTip$+ %Selected Submission's Assignment Name��6�   $��1��6�    � BindingGroup 6�   �� *AssignmentName+�� 5   
   -   5        $ textBoxCategoryName��5      $��23��6/   $��9.4,96,9.6,0q�6;   $
 Wrap=�6Q   $	��Top=�6e    . $) #Selected Submission's Category Name��6�   $��1��6�   �� 5   
   -   5        $ textBoxGrade��5      $��23��6(   $��9.4,127,9.6,0q�64   $
 Wrap=�6K   $	��Top=�6_    . $! Selected Submission's Grade��6�   $��1��6�   o� 5   
   $	��Top=�6   $��
0,0,-0.4,0q�6'   $��2��6;   .@�5      m� $
��File��6   $��0q�6%   $
��Left=�60   .@�5      m� -   5        	 m�Name$	 menuItemExit��5      $
��Exit��61   6?   5      m� 5      $��Import��6   .@�5      m� -   5        $	 menuItemImport��5      $ ��Course Work From JSON File��63   6W   5      m� 5      $
��Help��6   .@�5      m� -   5        $	 menuItemAbout��5      $��About��62   6A   5       5!      5#      5$      