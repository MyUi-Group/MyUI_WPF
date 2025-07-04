# MyUI
这是一个非常精美的WPF组件库，代码简洁、交互性强；开发者可循环地使用其组件，提高开发效率、加快进度；MyUI是作者根据实际项目中遇到的案例列整合开发而成，故而其易用性强、扩展性强、兼容性强、案例丰富

使用

步骤一：添加MyUi Nuget包；

Install-Package MyUi

步骤二：在 App.xaml 中添加代码如下：
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/ MyUi;component/ControlThemes/Theme_Base.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
    
步骤三：在目标页面添加需要的控件引用： xmlns:My="clr-namespace:MyUi.Controls;assembly=MyUi"

完成，起飞
![1](https://github.com/user-attachments/assets/696b7d12-6f27-4707-a815-78a0f583f013)
![2](https://github.com/user-attachments/assets/27f7f421-da64-4f37-8f1c-e2cc7138afa7)
![3](https://github.com/user-attachments/assets/fdd981ee-1f9f-4752-8c83-d1cad2a65da1)
