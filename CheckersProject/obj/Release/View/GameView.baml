   M S B A M L   `   `   `  ���� J  FCheckersProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CheckersProject.ViewModelCheckersProject.ViewModel  #    CheckersProject.View.GameView   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     6vm'clr-namespace:CheckersProject.ViewModel       � DataContext  -   'CheckersProject.ViewModel.GameViewModel  .���� -   .+��� $	��500��$	��500��
 �� Top$ 70�� �� Left$	 160������  �� ImageSource$! /Images/img_board_alien.png�� j� Stretch$
 Fill=��� ���� *DataContext.Pieces+ �� UpdateSourceTrigger$ PropertyChanged=� �� RelativeSource ��  �� AncestorType$ UserControlL����� .R��� $	��800��$	��450������ .���  �� Property �@��Left	 �� Value	 �� *X+��  �@��Top	 �� *Y+���� .R�A� $��40��$��40������ *Color+�� ���� *.,DataContext.SelectedPiece.ValidMovePositions+ �� $ UserControlL����� .R��� $	��800��$	��450������ .���  �@��Left	 �� *X+��  �@��Top	 �� *Y+���� .R�A� $��40��$��40��
��� ���$��3��
������ �� $	��208��$	��178��$	 694��$ 48��$��Center=�$	��Top=�
 �� CornerRadius$
 23��$��5q�����  �� 
TargetType" ��.���  � ��
	 ����  �� Triggers ��  �� Binding �� *IsBluePlayerTurn+ �� Value True.a���  � ��
	 � �����  �� *IsBluePlayerTurn+	 False.a���  � ��
	 ���� ._��� $&�� /Images/img_background_stats.png��$
��Fill=��� $	��208��$	��178��$	 694��$	 430��$��Center=�$	��Top=�$��5q�$
 23������ " ��.���  � ��
	 ����  ��  �� *IsGreenPlayerTurn+ True.a���  � ��
	 � �����  �� *IsGreenPlayerTurn+	 False.a���  � ��
	 ���� ._��� $&�� /Images/img_background_stats.png��$
��Fill=��� $'��!/Images/img_alien_green_stats.png��$��Uniform=�$��98��$	��102��$	 700��$ 69��$
��Left=�$	��Top=��� $&�� /Images/img_alien_blue_stats.png��$��Uniform=�$��74��$��74��$	 713��$	 460��$
��Left=�$	��Top=��� $	 794��$	 103��
������ $
��Left=�$��Center=�$��40��$��91��$��32(�$��Ink Free)�$
��Bold"����� *BluePlayer._name+�� $��Number of Pieces:��$	 726��$	 157��$��15(�$��Ink Free)�$
��Bold"�$
��Left=�$	��Top=�$	��120��$��26���� $	 846��$	 152��
������ $��30��$��27��$��20(�$��Impact)�$
��Bold"�$
��Left=�$	��Top=����� *BluePlayer.NumberPieces+�� $	 794��$	 476��
������ $��30��$��87��$��32(�$��Ink Free)�$
��Bold"����� *GreenPlayer._name+�� $��Number of Pieces:��$	 726��$	 540��$��15(�$��Ink Free)�$
��Bold"�$
��Left=�$	��Top=�$	��120��$��26���� $	 851��$	 535��
������ $
��Left=�$��26��$��Center=�$��29��$��20(�$��Impact)�$
��Bold"����� *GreenPlayer.NumberPieces+�� $��52��$��52��$ 6��$ 5������ *'%DataContext.BackFromGameToMenuCommand+ �� " ����� " ��.���  � ��
	 ���� ��  � ��
	 ���� ��  � ��$	 0q���  � ��	 ��  �� 
TargetType" ��.R���  ��Name$ 	imgButton��$*��$/Images/img_back_button_standard.png��$
��Fill=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ 	imgButton�� � ��$'	 !/Images/img_back_button_hover.png���� $��55��$��58��$ 68��$ 5��$
��Left=�$��Center=����� *SaveCommand+���� " ��.���  � ��
	 ���� ��  � ��
	 ���� ��  � ��$	 0q���  � ��	 �� " ��.R��� $ 	imgButton��$��/Images/img_save_game.png��$
��Fill=� P�  �@J�IsMouseOver . . ��� $ 	imgButton�� � ��$%	 /Images/img_save_game_hover.png���� $��52��$��52��$	 144��$ 5������ *LoadGameCommand+���� " ��.���  � ��
	 ���� ��  � ��
	 ���� ��  � ��$	 0q���  � ��	 �� " ��.R��� $ 	imgButton��$$��/Images/img_load_game_icon.png��$
��Fill=� P�  �@J�IsMouseOver . . ��� $ 	imgButton�� � ��$*	 $/Images/img_load_game_icon_hover.png��