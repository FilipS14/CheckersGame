   M S B A M L   `   `   `  ����J  FCheckersProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CheckersProject.ViewModelCheckersProject.ViewModel  5      $    CheckersProject.View.AboutView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6vm'clr-namespace:CheckersProject.ViewModel     5        � DataContext  5
      .   (CheckersProject.ViewModel.AboutViewModel  5   
   .��5      �� .+�5   
   �� $��52��5   	   $��52��6    �� Left$ 6��6    
 �� Top$ 5��60   ��5   	   �� *(&DataContext.BackFromAboutToMenuCommand+ �� RelativeSource ��  �� AncestorType" ���5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ���� 63   �� 5       � ��
 ���� 64   �� 5       � ��$ 0q�68   �� 5       � �� 5      �� 5       �� 
TargetType" ��6.   .R�5   "   �� 	 ��Name$	 	imgButton��6(   $*��$/Images/img_back_button_standard.png��6;   $
��Fill=�6i   
 �� Triggers
 5   "   P� 5   &    P� Property �@J�IsMouseOver P� Value . . �5   *   ��  �� 
TargetName$ 	imgButton��61    � ��$' !/Images/img_back_button_hover.png��6Z   5   '   5!      5#      5$      5&      �� 5(   
   $"��/Images/img_profil_about.png��5)      $
��Fill=�5*      $	��177��5+      $	��253��5,      $	 208��6   $	 121��6,   $��Center=�6=   $	��Top=�6Z   5.      �� 50   
   $!��/Images/img_alien_frame.png��51      $
��Fill=�52      $	��292��53      $	��335��54      $	 152��6   $ 78��6,   $
��Left=�6<   $	��Top=�6W   55      �� 57   
   $&�� /Images/img_alien_with_board.png��58      $
��Fill=�59      $	��430��5:      $	��546��5;      $	 493��6   $ 33��6,   $��Center=�6<   $	��Top=�6Y   5<      �� 5>   
   $��Nume: Sîrboiu Filip��5?      $��23(�5@      $
��Bold"�5A      
���   �$	 546��5B       $	 335��62   $��MV Boli)�5C      $��40��6"   $	��228��6.   $
��Left=�6:   $��Center=�6U   5D      �� 5F   
   $��Grupa: 10LF323��5G      $��23(�5H      $
��Bold"�5I      
���   �$	 547��5J       $	 379��62   $��MV Boli)�5K      $��40��6"   $	��228��6.   5M      �� 5O   
   $%��filip.sirboiu@student.unitbv.ro��5P      $��23(�5Q      $
��Bold"�5R      
���   �$	 546��5S       $	 416��62   $��MV Boli)�5T      $��40��6"   $	��348��6.   $
��Left=�6:   $	��Top=�6U   5V      �� 5X   
   $��Checkers Game��5Y      $��27(�5Z      $
��Bold"�5[      
���   �$	 546��5\       $	 456��62   $��MV Boli)�5]      $��40��6"   $	��348��6.   $
��Left=�6:   $	��Top=�6U   5_      5a      5b      