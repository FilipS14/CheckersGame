   M S B A M L   `   `   `  ���� J  FCheckersProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CheckersProject.ViewModelCheckersProject.ViewModel  #    CheckersProject.View.MenuView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6vm'clr-namespace:CheckersProject.ViewModel     $	��948��  � DataContext  -   'CheckersProject.ViewModel.MenuViewModel  .���� ����  �� ImageSource$% /Images/img_background_game.jpg��.+��� .+��� $��/Images/img_logo.png�� �� Left$	 391��
 �� Top$ 26��$	��211��$	��203��$��Center=�$	��Top=��� .+��� $!��/Images/img_green_alien.png��$	 -37��$ 94��$
��Left=�$	��520��$	��Top=�$	��490�� J� RenderTransformOrigin$ 
0.492,0.43&��� .+��� $ ��/Images/blue_alien_img.png��$	 666��$	 134��$
��Left=�$	��401��$	��Top=�$	��231���� $	 340��$	 250��$��Center=�$	��Top=�$	��310��$��90��$��4q����#04F6FF���� *%#DataContext.SwitchToGameViewCommand+ �� RelativeSource ��  �� AncestorType" �����  �� 
TargetType" ��.���  �� Property � ��	 �� Value	 �� 
 �� 
TargetType"
 ��.R���  ��Name$ border��#��z�����#009BFF#��z�� �� CornerRadius$ 55��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ border�� � ��	 �#1DDDDA.���� $��
Start Game��$��Center=�$��Center=�$
��Bold"�$��40(�$��Comic Sans MS)��� $	 340��$	 355��$
��Left=�$	��Top=�$	��310��$��90��$��4q����#04F6FF���� *(&DataContext.SwitchToOptionsViewCommand+ �� " ����� " ��.���  � ��	 �� "
 ��.R��� $ border��#��z�����#009BFF#��z��$ 55��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ border�� � ��	 �#1DDDDA.���� $��Options��$��Center=�$��Center=�$
��Bold"�$��40(�$��Comic Sans MS)��� $	 340��$	 460��$
��Left=�$	��Top=�$	��310��$��90��$��4q����#04F6FF���� *,*DataContext.SwitchToLeaderBoardViewCommand+ �� " ����� " ��.���  � ��	 �� "
 ��.R��� $ border��#��z�����#009BFF#��z��$ 55��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ border�� � ��	 �#1DDDDA.���� $��LeaderBoard��$��Center=�$��Center=�$
��Bold"�$��40(�$��Comic Sans MS)��� $��52��$��70��$ 1��$ 6��$
��Left=�$��Center=����� *&$DataContext.SwitchToAboutViewCommand+ �� " ����� " ��.���  � ��
	 ���� ��  � ��
	 ���� ��  � ��$	 0q���  � ��	 �� "
 ��.R���  ��Name$ 	imgButton��$ ��/Images/img_icon_about.png��$
��Fill=� P�  �@J�IsMouseOver . . ��� $ 	imgButton�� � ��$&	  /Images/img_icon_about_hover.png��