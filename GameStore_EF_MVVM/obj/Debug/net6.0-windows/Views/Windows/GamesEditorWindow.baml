   M S B A M L   `   `   `  ����L  HGameStore_EF_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:GameStore_EF_MVVM.Views.WindowsGameStore_EF_MVVM.Views.Windows  5   	   K*clr-namespace:GameStore_EF_MVVM.ViewModelsGameStore_EF_MVVM.ViewModels  5   	   7    1GameStore_EF_MVVM.Views.Windows.GamesEditorWindow   5   	   T PMathCore.WPF, Version=0.0.34.1, Culture=neutral, PublicKeyToken=38be1b026bbf82a9W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;l-clr-namespace:GameStore_EF_MVVM.Views.Windows     5   	   9vm*clr-namespace:GameStore_EF_MVVM.ViewModels     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	     � Title$  GamesEditorWindow��5
   	   $	��189��6#   $	��403��60   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   ��  �� Path$ LoadCategoriesCommand�  5       6$   �� $ LoadDevelopersCommand�5      .��5      ]� .+�5   
   A�  A� Rows$ 1��6   $��Bottom=�6   .+�5      �� $��OK��6   $
��Bold"�6"    �� 	IsDefault$
 True��64      DialogResultCommand#��[  6E   $
��true��5      �� 5      $��Отмена��6   #��[  6&   $��false��5      5      � 5   
    � ColumnDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6#   	 � RowDefinitions	 5!      �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    .+�5(      �� $��0��6   $��0��6(   $��Название��65   $��2��6E   $��
0,0,134,28q�6Y   $��2��6m   �� 5)      $��1��6   $��0��6&   $��
10,0,10,10q�6N   $��2��6b   ��63   �� $
 Name�6b   �� 5+      $��0��6   $��1��6(   $��Дата релиза��65   $��2��6H   $��	0,0,134,0q�6\   $��3��6o   (  "System.Windows.Controls.DatePicker  5,      $��1��6   $��1��6)   $��
10,0,10,10q�6`   $��2��6t   
   SelectedDate
 66   �� $ ReleaseDate�6t   �� 5.      $��0��6   $��2��6(   $��Жанр��65   �� 5/      $��1��6   $��2��6'   $��
10,0,10,10q�64    �� DisplayMemberPath$
 Name��52      ��50      �� $ 
Categories� �� SelectedItem 51      �� $ SelectedCategory�52      �� 54      $��0��6   $��3��6(   $��Разработчик��65   �� 55      $��1��6   $��3��6'   $��
10,0,10,10q�64   $
 Name��58      ��56      �� $ 
Developers� 57      �� $ SelectedDeveloper�58      59      5:      5;      