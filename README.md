# CalculatorUpdate
## Лабораторная работа №1 - Калькулятор
Made by Karpuchik E.V.
### Интерфейс калькулятора
![Alt text](https://s4.gifyu.com/images/GIFKA-S-Gifius.rud00c837c69aed1a4.gif)

Классический калькулятор, выполненный на Windows Forms, представляющий собой элементы Button для ввода чисел и взаимодействия между ними и Textbox для вывода операций пользователю. 

Калькулятор позволяет выполнять следующие операции:
- Сложение
- Вычитание
- Умножение
- Деление

Также интерфейс предусматривает:
- Очистку поля (действий) по кнопке **C**
- Изменение числа на положительное/отрицательное по кнопке **+/-**
- Вывод результата вычисления по кнопке **=**

Для удобства, добавлена возможность взаимодействие ввода цифр и всех операций с клавиатуры по соответствующим кнопкам.
> К дополнению, добавлена возможность стирание цифры по клавише *backspace*.

### Классы

#### Класс Calculate.cs
Класс содержит 4 метода c базовыми арифметическими операциями: 
```
public static int Sum(int firstOperand, int secondOperand)
        {
            int result = firstOperand + secondOperand;
            return result;
        }

        public static int Minus(int firstOperand, int secondOperand)
        {
            int result = firstOperand - secondOperand;
            return result;
        }

        public static int Multiple(int firstOperand, int secondOperand)
        {
            int result = firstOperand * secondOperand;
            return result;
        }

        public static int Devide(int firstOperand, int secondOperand)
        {
            int result = firstOperand / secondOperand;
            return result;
        }
```
#### Класс Form1.cs
Данный класс используется для графической интерпретации написанного кода и содержит 6 методов. Представленный ниже метод **Input** привязан к событию *Click* ко всем кнопкам с цифрами и позволяет вводить информацию в textBox 
```
        /// <summary>
        /// Method for entering a number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Input(object sender, EventArgs e)
        {
            try
            {
                if (flag)
                {
                    flag = false;
                    textBox1.Text = "";
                }
                Button button = (Button)sender;
                textBox1.Text += button.Text;
                label1.Focus();
            }
            catch
            {
                MessageBox.Show("Error");
                textBox1.Text = "";
            }
        }
```
Метод **Operation** привязан к событию *Click* для всех кнопок арифметических операций (+, -, *, /) и предсталяет собой действие (операцию) между двумя числами.
```
        /// <summary>
        /// Operation sign button selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Operation(object sender, EventArgs e)
        {
            if (!flag)
            {
                Button button = (Button)sender;
                action = button.Text;
                number1 = textBox1.Text;
                textBox1.Text += $" {action}";
                flag = true;
            }
```
Метод **Clear** привязан к событию *Click* кнопки **C** и и очищает поле *textBox1*.
```
        /// <summary>
        /// Clear textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear(object sender, EventArgs e)
        {
            textBox1.Text = "";
            flag = true;
        }
```
Метод **Swap** привязан к событию *Click* кнопки **+/-** и меняет знак числа, находящегося в поле *textBox1*.
```
        /// <summary>
        /// Changes the sign of a number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Swap(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = (int.Parse(textBox1.Text) * (-1)).ToString();
            }
        }
```
Метод **Equals** привязан к событию *Click* кнопки  =  и высчитывает результат операции между двумя числами
```
        /// <summary>
        /// The method calculates the result and output it to textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Equal(object sender, EventArgs e)
        {
            try
            {
                if ((int.TryParse(number1 as string, out int value1)) && (int.TryParse(textBox1.Text as String, out int value2)))
                {
                    int result = 0;
                    switch (action)
                    {
                        case "+":
                            result = Calculate.Sum(value1, value2);
                            break;
                        case "-":
                            result = Calculate.Minus(value1, value2);
                            break;
                        case "*":
                            result = Calculate.Multiple(value1, value2);
                            break;
                        case "/":
                            if (value2 != 0) result = Calculate.Devide(value1, value2);
                            else
                            {
                                MessageBox.Show("NOT / 0", "Error");
                                Clear(sender, e);
                            }

                            break;
                        default:
                            break;
                    }
                    textBox1.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Length exceeds 9 characters", "EXCEEDED");
                    Clear(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
```
Метод **Form1_KeyDown** представляет собой событие формы, происходящее в момент нажатия клавиши. Он добавлен с целью удобного взаимодействия калькулятором через клавиатуру.
```
        /// <summary>
        /// Method for keyboard input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.NumPad1) || e.KeyData.Equals(Keys.D1))
            {
                button1.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad2) || e.KeyData.Equals(Keys.D2))
            {
                button2.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad3) || e.KeyData.Equals(Keys.D3))
            {
                button3.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad4) || e.KeyData.Equals(Keys.D4))
            {
                button4.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad5) || e.KeyData.Equals(Keys.D5))
            {
                button5.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad6) || e.KeyData.Equals(Keys.D6))
            {
                button6.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad7) || e.KeyData.Equals(Keys.D7))
            {
                button7.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad8) || e.KeyData.Equals(Keys.D8))
            {
                button8.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.NumPad9) || e.KeyData.Equals(Keys.D9))
            {
                button9.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.D0) || e.KeyData.Equals(Keys.D0))
            {
                button10.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.Enter))
            {
                Equal(sender, e);
            }

            if (e.KeyCode.Equals(Keys.Subtract))
            {
                SubstractButton.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.Add))
            {
                SumButton.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.Multiply))
            {
                MultiplyButton.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.Divide))
            {
                DivideButton.PerformClick();
            }

            if (e.KeyCode.Equals(Keys.Back))
            {
                if (!flag)
                {
                    if (textBox1.TextLength != 1)
                    {
                        textBox1.Text = textBox1.Text[..^1];
                        textBox1.SelectionStart = textBox1.Text.Length;
                    }

                }
            }
        }
```
### UnitTest
Для проверки корректности производимых операций были добавлены тесты. Они тестируют методы, содержащиеся в отдельной библиотеке классов ClassOfCalcLibrary.cs, эквивалентной классу Calculate.cs, за исключением проверки деления на 0 в методе Divide:
```
if (secondOperand == 0)
            {
                throw new DivideByZeroException();
            }
```
Код тестов представлен ниже:
```
namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(10, 7)]
        [DataRow(13, 53)]
        public void TestSum(int a, int b)
        {
            var expResult = a + b;

            var result = ClassOfCalcLibrary.Sum(a, b);

            Assert.AreEqual(result, expResult);
        }

        [TestMethod]
        [DataRow(13, 4)]
        [DataRow(4234, 5423)]
        public void TestMinus(int a, int b)
        {
            var expResult = a - b;

            var result = ClassOfCalcLibrary.Minus(a, b);

            Assert.AreEqual(result, expResult);
        }

        [TestMethod]
        [DataRow(8, 4)]
        [DataRow(5532, 135)]
        public void TestMultiple(int a, int b)
        {
            var expResult = a * b;

            var result = ClassOfCalcLibrary.Multiple(a, b);

            Assert.AreEqual(result, expResult);
        }

        [TestMethod]
        [DataRow(10, 2)]
        [DataRow(4224, 8954)]
        public void TestDivide(int a, int b)
        {
            var expResult = a / b;

            var result = ClassOfCalcLibrary.Devide(a, b);

            Assert.AreEqual(result, expResult);
        }

        [TestMethod]
        [DataRow(10, 0)]
        [DataRow(14248, 0)]
        [ExpectedException(typeof(DivideByZeroException), "Oh my god, we can't divison on zero :(")]
        public void TestDivideByZero(int a, int b)
        {
           var result = ClassOfCalcLibrary.Devide(a, b);            
        }

        /*[TestMethod]
        [DataRow(2147483648, 2)]
        [ExpectedException(typeof(ArgumentException), "Object of type 'System.UInt32' cannot be converted to type 'System.Int32'.")]
        public void HandlingExceptionForExceedingInt(int a, int b)
        {
           
        }
        */
    }
```
##### Результат прохождения тестов:
![Alt Text](https://sun1.ncot-by-minsk.userapi.com/impg/zwHPIy2nY2epTWhbK3pUCokYinOxtrIIUyXe4w/LS8i8KTmso8.jpg?size=807x411&quality=96&sign=27f59ccb5dacf54367c7e9c844a7a5b7&type=album)

Исходя из успешного прохождения тестов можно сделать вывод о том, что калькулятор работает корректно.
