   M S B A M L   `   `   `  ���� J  FCheckersProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CheckersProject.ViewModelCheckersProject.ViewModel  *    $CheckersProject.View.LeaderBoardView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6vm'clr-namespace:CheckersProject.ViewModel       � DataContext  4   .CheckersProject.ViewModel.LeaderBoardViewModel  .���� .+��� $��52��$��52�� �� Left$ 6��
 �� Top$ 6������ *.,DataContext.BackFromLeaderBoardToMenuCommand+ �� RelativeSource ��  �� AncestorType" �����  �� 
TargetType" ��.���  �� Property � �� �� Value
 ���� ��  � ��
 ���� ��  � ��$ 0q���  � �� ��  �� 
TargetType" ��.R��� 	 ��Name$	 	imgButton��$*��$/Images/img_back_button_standard.png��$
��Fill=�
 �� Triggers
 P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ 	imgButton�� � ��$' !/Images/img_back_button_hover.png���� $,��&/Images/img_background_leaderboard.png��$	��616��$	��608��$��UniformToFill=�$ 48��$	 197���� $	��338��$
��Left=�$	��295��$	��Top=�$	 339��$	 212�����#F5F5F5���#CCCCCC$��1q����� *	Players+���� .R��� ���#CCCCCC$��1q�$��5q� �� CornerRadius$ 5��
�������._��� $	��280��$��40��.+��� $ 45��$ 10��$��16(����#333333$��Center=�$��Center=�$��62������ *_name+�� $	 120��$ 10��$��16(����#007ACC J� RenderTransformOrigin$ 1.837,0.611&�$
��Left=�$��Center=����� *_wins+�� $	 190��$ 10��$��16(����#FF4500���� *	_losses+�� $!��/Images/img_icon_member.png��$ 5��$ 5��$��30��$��30��