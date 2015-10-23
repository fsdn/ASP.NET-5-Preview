#ASP.NET 5 Preview

#Tool：VisualStudio2015

#param mark -- DNX dnx版本“dnx-clr-win-x86.1.0.0-beta5”无法安装
解决办法：</br>
1、运行cmd(最好是管理员权限) --> </br>
@powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'</br>
上面代码，会自动下载安装。</br>
2、cmd --></br>
dnvm upgrade</br>
上面代码，你会下载更新到最新版本的DNX</br>
3、cmd --></br>
dnvm install 1.0.0-beta5</br>
上面代码，会重装“1.0.0-beta5”版本的，因为VisualStudio2015的项目创建的引用就是这个版本，即使你装了最新的也会报错。</br>
4、配置环境变量</br>
c:\Users\Administrator\.dnx\runtimes\dnx-clr-win-x86.1.0.0-beta5\bin</br>
简单说下：“Administrator”指的是你的用户名，每一个人的电脑都可能不一样的。</br>
环境变量的配置：桌面 --> 右键我的电脑 --> 高级系统设置 --> 环境变量 --> 用户变量|系统变量 Path都要设置。</br>
5、完毕 CTL+F5 运行，可以不执行断点调试。</br>
