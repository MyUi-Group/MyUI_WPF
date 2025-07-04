
# MyUI

这是一个非常精美的WPF组件库，代码简洁、交互性强；开发者可循环地使用其组件，提高开发效率、加快进度；
MyUI是作者根据实际项目中遇到的案例列整合开发而成，故而其易用性强、扩展性强、兼容性强、案例丰富,不断完善中，也欢迎广大码友提供宝贵的建议

## 技术交流

| 联系方式             |                                                                |
| ----------------- | ------------------------------------------------------------------ | 
| QQ |  2638662731(暗号：嫂子好不好)|
| 邮箱 |  qq2638662731@163.com| 
## 学习文档
[在线文档](待完善)  
## 作者
- [我吃土豆丝/MyUi-Group](https://github.com/2638662731) 

## 想找我外包？
WPF前端后端、上位机等外包联系 QQ : 2638662731 微信：TCDJ999999666
## 鼓励打赏？
![MONEY](https://github.com/user-attachments/assets/957c65ef-ba56-4361-bf30-d1feec652e42)



## 使用

步骤一 : 添加LayUI.Wpf Nuget包;

```Install-Package MyUi```

步骤二 : 添加代码在 App.xaml 下面:
```XML
<Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/ MyUi;component/ControlThemes/Theme_Base.xaml" />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
``` 
步骤三: 在目标页面添加需要的控件引用:
`xmlns:My="clr-namespace:MyUi.Controls;assembly=MyUi"`

步骤四: 完成 

## 截图
![1](https://github.com/user-attachments/assets/696b7d12-6f27-4707-a815-78a0f583f013)
![2](https://github.com/user-attachments/assets/27f7f421-da64-4f37-8f1c-e2cc7138afa7)
![3](https://github.com/user-attachments/assets/fdd981ee-1f9f-4752-8c83-d1cad2a65da1)


