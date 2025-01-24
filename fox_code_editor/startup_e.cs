using System.IO;
using System;

namespace fox_code_editor.startup_e
{
    public class StartupClass
    {
        private void theme__s()
        {


            try
            {
                using (StreamReader sr = new StreamReader(outputFilePath))
                {


                    // 1行目を読み飛ばす
                    sr.ReadLine();

                    // 2行目を取得
                    secondLine = sr.ReadLine();



                }



                this_color = secondLine.Replace("color setting: ", "");

                if (this_color == "black")
                {
                    dark = true;
                    window_main.Background = new SolidColorBrush(Color.FromArgb(255, 85, 85, 85));
                    file.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    help.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    devtools.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    setting_.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));


                }
                else
                {
                    dark = false;
                    window_main.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));


                }



            }

            catch (Exception ex)
            {

            }

        }

    }
}