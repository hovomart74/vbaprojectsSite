﻿Public Class Form1
    'создаём переменную, читающую путь стартовой папки 
    Dim PutPapkiFotoZubr As String
    'переменная сохраняющая количество фото от Зубр
    Dim KolichFotoZubr As Long
    'массив сохраняет названия фоток от Зубр с путями
    Dim MasImenaFotoZubr() As String
    'ссылка на прайс
    Dim PutPrais As String
    'массив с прайсом
    Dim MasPraisZubr(0, 0) As String
    'переменная сохраняет количество строк в прайсе
    Dim Strochek As Long
    'переменная сохраняет количество столбцов в прайсе
    Dim Stolbcov As Long = 25
    'массив с обработаным прайсом
    Dim MasNovPrais(0, 0) As String


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'при загрузке формы сразу проверяем наличие файла "PutPapkiFotoZubr.txt"
        ProverPutPapkiFotoZubr()
    End Sub

    Private Sub ProverPutPapkiFotoZubr() 'микропрограмма проверки наличия файла "PutPapkiFotoZubr.txt"
        'строка проверяет наличие
        If My.Computer.FileSystem.FileExists("PutPapkiFotoZubr.txt") Then
            'при её наличии считываем из неё последний путь к папке с фотками
            PutPapkiFotoZubr = My.Computer.FileSystem.ReadAllText("PutPapkiFotoZubr.txt")
            'путь записываем в Текстбокс
            MaskedTextBox1.Text = PutPapkiFotoZubr
        Else
            'при её отсутствии создаём файл "PutPapkiFotoZubr.txt"
            My.Computer.FileSystem.WriteAllText("PutPapkiFotoZubr.txt", "Тут будет путь к фоткам от Зубра", True)
            MaskedTextBox1.Text = My.Computer.FileSystem.ReadAllText("PutPapkiFotoZubr.txt")
            PutPapkiFotoZubr = ""
        End If
    End Sub



    Private Sub PapkaFoto_Click(sender As Object, e As EventArgs) Handles PapkaFoto.Click
        'запускаем вытаскивание и назначение стартового пути к фоткам
        PapkaFotoZubr()
    End Sub

    'запускаем вытаскивание и назначение стартового пути к фоткам
    Private Sub PapkaFotoZubr()
        'вытаскиваем и назначаем стартовый путь
        FolderBrowserDialog1.SelectedPath = PutPapkiFotoZubr
        'Фиксируем путь к папке с фотками от Зубр
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            'присваиваем переменной выбранный путь
            PutPapkiFotoZubr = FolderBrowserDialog1.SelectedPath
            'заодно вписываем в TextBox
            MaskedTextBox1.Text = PutPapkiFotoZubr
            'очищяем содержимое файла "PutPapkiFotoZubr.txt"
            'удаляем файл
            My.Computer.FileSystem.DeleteFile("PutPapkiFotoZubr.txt")
            'Записываем этот путь в новый файл, чтобы каждый раз не повторять фиксацию папки
            My.Computer.FileSystem.WriteAllText("PutPapkiFotoZubr.txt", PutPapkiFotoZubr, True)
        End If
    End Sub

    Private Sub Pusk_Click(sender As Object, e As EventArgs) Handles Pusk.Click
        'запускаем ProgressBar
        ProgressBar1.Value = 0
        For I As Integer = 1 To 100
            Application.DoEvents()
            ProgressBar1.Value = ProgressBar1.Value + 1
            System.Threading.Thread.Sleep(2)
        Next

        'проверяем наличие выбранных файлов и папок
        If My.Computer.FileSystem.DirectoryExists(MaskedTextBox1.Text) = True And
            My.Computer.FileSystem.FileExists(MaskedTextBox2.Text) = True Then
            'при их наличии запускаем заполнение всех массивов
            'заполнение массива с прайсом от зубра
            ZapolnMasPraisZubr()
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'заполнение массива новый прайс
            'заполняем столбец №1 массива "Код товара (model)" нового прайса
            KodTovaraModel()
            'заполняем столбец №2 массива "Артикул" нового прайса 
            Artikul()
            'заполняем столбец №3 массива "Название товара" нового прайса 
            NazvanieTovara()
            'заполняем столбец №4 массива "Цена на сайте" нового прайса 
            CenaNaSite()
            'заполняем столбец №5 массива "UPC единица измерения" нового прайса 
            UPCedinicaIzmer()
            'заполняем столбец №6 массива "Название производителя" нового прайса 
            Proizvoditel()
            'заполняем столбец №7 массива "Описание" (страна производитель) нового прайса
            Opisanie()
            'заполняем столбец №8 массива "Мета-тег Title" нового прайса
            MetaTegTitle()
            'заполняем столбец №9 массива "Мета-тег Description" нового прайса
            MetaTegDescription()
            'заполняем столбец №10 массива "Минимальное количество" нового прайса
            MinimalKolich()
            'заполняем столбец №11 массива "Категории вместе с путем" нового прайса
            KategoriaGlavn()
            'заполняем столбец №12 массива "Вычитать со склада" нового прайса
            VichitatSoSklada()
            'заполняем столбец №13 массива "Необходима доставка" нового прайса
            NeobxadimaDostavka()

            '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'это оставляем в конце
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            'запускаем заполнение массива ImenaFotoZubr
            ZapolnMasFotoZubr()

            'заполняем столбец №14 массива "Дополнительные изображения товара" нового прайса
            FotkiVPrise()

            'копируем используемые фотки в новую папку для FileZilla
            FotkiVPapku()

            'по окончании всех работ открывается сообщение
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
        'MsgBox("Готово!", 0, "Готово!")
        Else
        'при отсутствии нужных папок выводим сообщение
        MsgBox("Заполните пожалуйста все поля правильно")
        End If
    End Sub

    Private Sub ZapolnMasFotoZubr()
        'считаем количество файлов в папке
        KolichFotoZubr = IO.Directory.GetFiles(PutPapkiFotoZubr).Count
        'назначаем количество элементов массива ImenaFotoZubr
        ReDim MasImenaFotoZubr(KolichFotoZubr - 1)
        'заливаем массив именами файлов с путями
        MasImenaFotoZubr = IO.Directory.GetFiles(PutPapkiFotoZubr)
    End Sub

    Private Sub ViborPraisZubr_Click(sender As Object, e As EventArgs) Handles ViborPraisZubr.Click
        'запускаем диалоговое окно выбора файла
        OpenFileDialog1.ShowDialog()
        'сохраняем путь к прайсу в переменной
        PutPrais = OpenFileDialog1.FileName
        'сохраняем путь к прайсу в TextBox
        MaskedTextBox2.Text = PutPrais
    End Sub

    'заполнение массива с прайсом от зубра
    Private Sub ZapolnMasPraisZubr()
        'списано из учебника
        'Объявляем переменные счетчика
        Dim row, col, finalRow, finalCol As Long
        'Открываем электронную таблицу
        Dim xl = CreateObject("Excel.application")
        xl.Workbooks.Open(PutPrais)
        'активация нужного листа в книге Эксель
        xl.Worksheets("Price").activate()
        'Подсчитиваем количество используемых строк и столбцов
        finalRow = xl.ActiveSheet.UsedRange.Rows.Count
        finalCol = xl.ActiveSheet.UsedRange.Columns.Count
        'меняем розмеры массива
        ReDim MasPraisZubr(finalRow, finalCol)
        'создаю переменную РАЗНица, чтобы новый массив прайса не включал удалённые строки 
        Dim Razn As Long = 0
        'цикл заполняющий массив прайсом от Зубра
        For row = 1 To finalRow
            'проверка столбца №4 "цены" на наличие информации
            'проверка столбца №2 "Название товара"
            'проверка столбца №11 "Код товара"
            If (xl.ActiveSheet.Cells(row, 4).Value) Is Nothing OrElse
                (xl.ActiveSheet.Cells(row, 4).Value) = "0" OrElse
                (xl.ActiveSheet.Cells(row, 11).Value) Is Nothing OrElse
                (xl.ActiveSheet.Cells(row, 2).Value) Is Nothing Then
                Razn = Razn + 1
            Else
                For col = 1 To finalCol
                    MasPraisZubr(row - Razn, col) = Trim(xl.ActiveSheet.Cells(row, col).Value)
                Next col
            End If
        Next row

        'назначаем количество строк переменной
        Strochek = finalRow - Razn
        ReDim MasNovPrais(Strochek, Stolbcov)
        ' Release resources.
        xl.Workbooks.Close()
        xl = Nothing
    End Sub

    'заполняем столбец №1 массива "Код товара (model)" нового прайса 
    Private Sub KodTovaraModel()
        MasNovPrais(1, 1) = "Код товара (model)"
        For i = 2 To Strochek
            MasNovPrais(i, 1) = "ЗСК" & MasPraisZubr(i, 11)
        Next
    End Sub

    'заполняем столбец №2 массива "Артикул" нового прайса 
    Private Sub Artikul()
        MasNovPrais(1, 2) = "Артикул"
        For i = 2 To Strochek
            MasNovPrais(i, 2) = MasPraisZubr(i, 1)
        Next
    End Sub

    'заполняем столбец №3 массива "Название товара" нового прайса 
    Private Sub NazvanieTovara()
        MasNovPrais(1, 3) = "Название товара"
        For i = 2 To Strochek
            MasNovPrais(i, 3) = MasPraisZubr(i, 2)
        Next
    End Sub

    'заполняем столбец №4 массива "Цена на сайте" нового прайса 
    Private Sub CenaNaSite()
        MasNovPrais(1, 4) = "Цена на сайте"
        For i = 2 To Strochek
            MasNovPrais(i, 4) = MasPraisZubr(i, 4) * 2.2
        Next
    End Sub

    'заполняем столбец №5 массива "UPC единица измерения" нового прайса 
    Private Sub UPCedinicaIzmer()
        MasNovPrais(1, 5) = "UPC"
        For i = 2 To Strochek
            MasNovPrais(i, 5) = "/" & MasPraisZubr(i, 3) & "."
        Next
    End Sub

    'заполняем столбец №6 массива "Название производителя" нового прайса 
    Private Sub Proizvoditel()
        MasNovPrais(1, 6) = "Название производителя"
        For i = 2 To Strochek
            MasNovPrais(i, 6) = MasPraisZubr(i, 9)
        Next
    End Sub

    'заполняем столбец №7 массива "Описание" (страна производитель) нового прайса
    Private Sub Opisanie()
        MasNovPrais(1, 7) = "Описание"
        For i = 2 To Strochek
            Select Case MasNovPrais(i, 6)
                Case Is = "DEXX"
                    MasNovPrais(i, 7) = "Китай"
                Case Is = "Зубр"
                    MasNovPrais(i, 7) = "Россия"
                Case Is = "СИБИН"
                    MasNovPrais(i, 7) = "Россия"
                Case Is = "Stayer"
                    MasNovPrais(i, 7) = "Россия"
                Case Is = "Тевтон"
                    MasNovPrais(i, 7) = "Китай"
                Case Is = "MIRAX"
                    MasNovPrais(i, 7) = "Китай"
                Case Is = "Kraftool"
                    MasNovPrais(i, 7) = "Япония"
                Case Is = "Uragan"
                    MasNovPrais(i, 7) = "Китай"
                Case Is = "РОССИЯ"
                    MasNovPrais(i, 7) = "Россия"
                Case Is = "Grinda"
                    MasNovPrais(i, 7) = "Финляндия"
                Case Is = "НИЗ"
                    MasNovPrais(i, 7) = "Россия"
                Case Is = "Legioner"
                    MasNovPrais(i, 7) = "Китай"
                Case Is = "ТИЗ"
                    MasNovPrais(i, 7) = "Россия"
                Case Is = "Rapid"
                    MasNovPrais(i, 7) = "Швеция"
                Case Is = "ЛУГА"
                    MasNovPrais(i, 7) = "Россия"
                Case Is = "БАЗ"
                    MasNovPrais(i, 7) = "Россия"
                Case Is = "Keter"
                    MasNovPrais(i, 7) = "Израиль"
                Case Is = "РОСТОК"
                    MasNovPrais(i, 7) = "Россия"
                Case Is = "ТРУД ВАЧА"
                    MasNovPrais(i, 7) = "Россия"
                Case Is = "Raco"
                    MasNovPrais(i, 7) = "Германия"
                Case Is = "СВЕТОЗАР"
                    MasNovPrais(i, 7) = "Россия"
                Case Is = "GENERAL FITTINGS"
                    MasNovPrais(i, 7) = "Германия"
                Case Is = "JCB"
                    MasNovPrais(i, 7) = "Великобритания"
                Case Is = "OLFA"
                    MasNovPrais(i, 7) = "Япония"
                Case Else
                    MasNovPrais(i, 7) = "Noname"
            End Select
        Next
    End Sub

    'заполняем столбец №8 массива "Мета-тег Title" нового прайса
    Private Sub MetaTegTitle()
        MasNovPrais(1, 8) = "Мета-тег Title"
        For i = 2 To Strochek
            MasNovPrais(i, 8) = MasNovPrais(i, 3) & " за " & MasNovPrais(i, 4) & " ₽" & MasNovPrais(i, 5) & " Вы можете купить в Москве у нас"
        Next
    End Sub

    'заполняем столбец №9 массива "Мета-тег Description" нового прайса
    Private Sub MetaTegDescription()
        MasNovPrais(1, 9) = "Мета-тег Description"
        For i = 2 To Strochek
            MasNovPrais(i, 9) = MasNovPrais(i, 3) & " за " & MasNovPrais(i, 4) & " ₽" & MasNovPrais(i, 5) & " купить недорого в Москве"
        Next
    End Sub

    'заполняем столбец №10 массива "Минимальное количество" нового прайса
    Private Sub MinimalKolich()
        MasNovPrais(1, 10) = "Минимальное количество"
        For i = 2 To Strochek
            MasNovPrais(i, 10) = "1"
        Next
    End Sub

    'заполняем столбец №11 массива "Категории вместе с путем" нового прайса
    Private Sub KategoriaGlavn()
        MasNovPrais(1, 11) = "Категории вместе с путем"
        For i = 2 To Strochek
            MasNovPrais(i, 11) = "Инструмент"
        Next
    End Sub

    'заполняем столбец №12 массива "Вычитать со склада" нового прайса
    Private Sub VichitatSoSklada()
        MasNovPrais(1, 12) = "Вычитать со склада"
        For i = 2 To Strochek
            MasNovPrais(i, 12) = "0"
        Next
    End Sub

    'заполняем столбец №13 массива "Необходима доставка" нового прайса
    Private Sub NeobxadimaDostavka()
        MasNovPrais(1, 13) = "Необходима доставка"
        For i = 2 To Strochek
            MasNovPrais(i, 13) = "1"
        Next
    End Sub



    'заполняем столбец №14 массива "Дополнительные изображения товара" нового прайса
    Private Sub FotkiVPrise()
        Dim MasVrem1() As String
        Dim MasVrem2() As String
        'массив фоток с новой ссылкой на сервере
        Dim MasFotoNovSSilka() As String = Array.ConvertAll(MasImenaFotoZubr,
                                                    Function(str) _
                                                        Replace(str, PutPapkiFotoZubr & "\", "catalog/002/"))
        Dim MasVrem4() As String
        'заполняем заголовок столбца
        MasNovPrais(1, 14) = "Дополнительные изображения товара"
        For i = 2 To Strochek
            'при фильтрации спереди добавляем часть пути, чтобы не лезли похожие артикулы
            'сначала делаем поиск с точкой после артикула (главное фото)
            MasVrem1 = Filter(MasFotoNovSSilka, "002/" & MasNovPrais(i, 2) & ".", True, CompareMethod.Text)
            'затем поиск с нижним подчёркивание (остальные фотки), и не лезут похожие артикулы
            MasVrem2 = Filter(MasFotoNovSSilka, "002/" & MasNovPrais(i, 2) & "_", True, CompareMethod.Text)
            ReDim MasVrem4(MasVrem1.Length + MasVrem2.Length - 1)
            For j = 0 To ((MasVrem4.Length - MasVrem2.Length) - 1)
                MasVrem4(j) = MasVrem1(j)
            Next j

            For k = 0 To ((MasVrem4.Length - MasVrem1.Length) - 1)
                MasVrem4(k + MasVrem1.Length) = MasVrem2(k)
            Next k

            MasNovPrais(i, 14) = Join(MasVrem4, "|")

        Next i
    End Sub

    'копируем используемые фотки в новую папку для FileZilla
    Private Sub FotkiVPapku()
        Dim MasVrem1() As String
        Dim MasVrem2() As String
        For i = 0 To Strochek
            'при фильтрации спереди добавляем часть пути, чтобы не лезли похожие артикулы
            'сначала делаем поиск с точкой после артикула (главное фото)
            MasVrem1 = Filter(MasImenaFotoZubr, PutPapkiFotoZubr & "\" & MasNovPrais(i, 2) & ".", True, CompareMethod.Text)
            For j = 0 To MasVrem1.Length - 1
                FileIO.FileSystem.CopyFile(MasVrem1(j), "D:\фото зубр стаер\" & FileIO.FileSystem.GetName(MasVrem1(j)))
            Next j
            'затем поиск с нижним подчёркиванием (остальные фотки), и не лезут похожие артикулы
            MasVrem2 = Filter(MasImenaFotoZubr, PutPapkiFotoZubr & "\" & MasNovPrais(i, 2) & "_", True, CompareMethod.Text)
            For k = 0 To MasVrem2.Length - 1
                FileIO.FileSystem.CopyFile(MasVrem2(k), "D:\фото зубр стаер\" & FileIO.FileSystem.GetName(MasVrem2(k)))
            Next k
        Next i
    End Sub


End Class