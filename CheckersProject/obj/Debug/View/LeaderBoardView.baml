   M S B A M L   `   `   `  ����J  FCheckersProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CheckersProject.ViewModelCheckersProject.ViewModel  5      *    $CheckersProject.View.LeaderBoardView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6vm'clr-namespace:CheckersProject.ViewModel     5        � DataContext  5
      4   .CheckersProject.ViewModel.LeaderBoardViewModel  5   
   .��5      �� .+�5   
   �� $��52��5      $��52��6    �� Left$ 6��6$   
 �� Top$ 6��64   ��5      �� *.,DataContext.BackFromLeaderBoardToMenuCommand+ �� RelativeSource ��  �� AncestorType" ���5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ���� 63   �� 5       � ��
 ���� 64   �� 5       � ��$ 0q�68   �� 5       � �� 5      �� 5       �� 
TargetType" ��6.   .R�5   "   �� 	 ��Name$	 	imgButton��6(   $*��$/Images/img_back_button_standard.png��6;   $
��Fill=�6i   
 �� Triggers
 5   "   P� 5   &    P� Property �@J�IsMouseOver P� Value . . �5   *   ��  �� 
TargetName$ 	imgButton��61    � ��$' !/Images/img_back_button_hover.png��6Z   5   '   5!      5#      5$      5&      �� 5(   
   $,��&/Images/img_background_leaderboard.png��6   $	��616��5)      $	��608��5*      $��UniformToFill=�5+      $ 48��6$   $	 197��64   �� 5-   
   $	��338��5.   
   $
��Left=�5/   
   $	��295��50   
   $	��Top=�51   
   $	 339��52   
   $	 212��53   
   ���#F5F5F5���#CCCCCC$��1q�56   
   ��5-      �� *	Players+��57      �� 58      .R�59      �� ���#CCCCCC$��1q�5:      $��5q�5;       �� CornerRadius$ 5��5<      
�������._�5>      �� $	��280��6!   $��40��6-   .+�5?      �� $ 45��5@       $ 10��5A       $��16(�5B       ���#333333$��Center=�5C   5   $��Center=�6R   $��62��6m   ��5?   (   �� *_name+5C   m   �� 5D      $	 120��5E       $ 10��5F       $��16(�5G       ���#007ACC J� RenderTransformOrigin$ 1.837,0.611&�5H   5   $
��Left=�6Y   $��Center=�6t   ��5D   (   �� *_wins+5H   t   �� 5I      $	 190��5J       $ 10��5K       $��16(�5L       ���#FF4500��5I   (   �� *	_losses+5M       �� 5O      $!��/Images/img_icon_member.png��6$   $ 5��5P      $ 5��5Q      $��30��5R      $��30��5S      5T      5U      5V      5X      5\      5]      