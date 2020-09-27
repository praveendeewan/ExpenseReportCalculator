using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using Microsoft.Win32;
using Microsoft.Office.Interop.Excel;

namespace ExpenseReportCalculator
{
    class ExpenseViewModel : DependencyObject, INotifyPropertyChanged, IDataErrorInfo
    {
        public ExpenseViewModel()
        {
            totalPeople = new List<int>();
            populate();
            TextBoxValidation();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, (new PropertyChangedEventArgs(propertyName)));
        }
        
        private void populate()
        {
            totalPeople.Add(2);
            totalPeople.Add(3);
            totalPeople.Add(4);
            totalPeople.Add(5);
        }
        private List<int> totalPeople;
        public List<int> TotalPeople
        {
            get { return totalPeople; }
            set
            {
                if (totalPeople != value)
                {
                    totalPeople = value;
                    NotifyPropertyChanged("TotalPeople");
                }
            }
        }

        private int selectedPeopleNumber;
        public int SelectedPeopleNumber
        {
            get { return selectedPeopleNumber; }
            set
            {
                if (selectedPeopleNumber != value)
                {
                    selectedPeopleNumber = value;
                    NotifyPropertyChanged("SelectedPeopleNumber");
                    this.TextBoxValidation();
                }
            }
        }

        //public int SelectedPeopleNumber
        //{
        //    get { return (int)GetValue(SelectedPeopleNumberProperty); }
        //    set { SetValue(SelectedPeopleNumberProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for SelectedPeopleNumber.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty SelectedPeopleNumberProperty =
        //    DependencyProperty.Register("SelectedPeopleNumber", typeof(int), typeof(ExpenseViewModel), new PropertyMetadata(0));


        public ObservableCollection<int> Roommate1List
        {
            get { return (ObservableCollection<int>)GetValue(Roommate1ListProperty); }
            set { SetValue(Roommate1ListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Roommate1List.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Roommate1ListProperty =
            DependencyProperty.Register("Roommate1List", typeof(ObservableCollection<int>), typeof(ExpenseViewModel), new UIPropertyMetadata(new ObservableCollection<int>()));


        public ObservableCollection<int> Roommate2List
        {
            get { return (ObservableCollection<int>)GetValue(Roommate2ListProperty); }
            set { SetValue(Roommate2ListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Roommate2List.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Roommate2ListProperty =
            DependencyProperty.Register("Roommate2List", typeof(ObservableCollection<int>), typeof(ExpenseViewModel), new UIPropertyMetadata(new ObservableCollection<int>()));




        public ObservableCollection<int> Roommate3List
        {
            get { return (ObservableCollection<int>)GetValue(Roommate3ListProperty); }
            set { SetValue(Roommate3ListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Roommate3List.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Roommate3ListProperty =
            DependencyProperty.Register("Roommate3List", typeof(ObservableCollection<int>), typeof(ExpenseViewModel), new UIPropertyMetadata(new ObservableCollection<int>()));



        public ObservableCollection<int> Roommate4List
        {
            get { return (ObservableCollection<int>)GetValue(Roommate4ListProperty); }
            set { SetValue(Roommate4ListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Roommate4List.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Roommate4ListProperty =
            DependencyProperty.Register("Roommate4List", typeof(ObservableCollection<int>), typeof(ExpenseViewModel), new UIPropertyMetadata(new ObservableCollection<int>()));




        public ObservableCollection<int> Roommate5List
        {
            get { return (ObservableCollection<int>)GetValue(Roommate5Property); }
            set { SetValue(Roommate5Property, value); }
        }

        // Using a DependencyProperty as the backing store for Roommate5.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Roommate5Property =
            DependencyProperty.Register("Roommate5List", typeof(ObservableCollection<int>), typeof(ExpenseViewModel), new UIPropertyMetadata(new ObservableCollection<int>()));


        //public string Roommate1Expenses
        //{
        //    get { return (string)GetValue(Roommate1ExpensesProperty); }
        //    set { SetValue(Roommate1ExpensesProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Roommate1Expenses.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty Roommate1ExpensesProperty =
        //    DependencyProperty.Register("Roommate1Expenses", typeof(string), typeof(ExpenseViewModel), new PropertyMetadata(null));
        private string _roommate1Expenses;
        public string Roommate1Expenses
        {
            get
            {
                return this._roommate1Expenses;
            }
            set
            {
                this._roommate1Expenses = value;
                NotifyPropertyChanged("Roommate1Expenses");
            }
        }


        //public string Roommate2Expenses
        //{
        //    get { return (string)GetValue(Roommate2ExpensesProperty); }
        //    set { SetValue(Roommate2ExpensesProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Roommate2Expenses.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty Roommate2ExpensesProperty =
        //    DependencyProperty.Register("Roommate2Expenses", typeof(string), typeof(ExpenseViewModel), new PropertyMetadata(null));

        private string _roommate2Expenses;
        public string Roommate2Expenses
        {
            get
            {
                return this._roommate2Expenses;
            }
            set
            {
                this._roommate2Expenses = value;
                NotifyPropertyChanged("Roommate2Expenses");
            }
        }


        //public string Roommate3Expenses
        //{
        //    get { return (string)GetValue(Roommate3ExpensesProperty); }
        //    set { SetValue(Roommate3ExpensesProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Roommate3Expenses.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty Roommate3ExpensesProperty =
        //    DependencyProperty.Register("Roommate3Expenses", typeof(string), typeof(ExpenseViewModel), new PropertyMetadata(null));

        private string _roommate3Expenses;
        public string Roommate3Expenses
        {
            get
            {
                return this._roommate3Expenses;
            }
            set
            {
                this._roommate3Expenses = value;
                NotifyPropertyChanged("Roommate3Expenses");
            }
        }


        //public string Roommate4Expenses
        //{
        //    get { return (string)GetValue(Roommate4ExpensesProperty); }
        //    set { SetValue(Roommate4ExpensesProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Roommate4Expenses.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty Roommate4ExpensesProperty =
        //    DependencyProperty.Register("Roommate4Expenses", typeof(string), typeof(ExpenseViewModel), new PropertyMetadata(null));

        private string _roommate4Expenses;
        public string Roommate4Expenses
        {
            get
            {
                return this._roommate4Expenses;
            }
            set
            {
                this._roommate4Expenses = value;
                NotifyPropertyChanged("Roommate4Expenses");
            }
        }

        //public string Roommate5Expenses
        //{
        //    get { return (string)GetValue(Roommate5ExpensesProperty); }
        //    set { SetValue(Roommate5ExpensesProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Roommate5Expenses.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty Roommate5ExpensesProperty =
        //    DependencyProperty.Register("Roommate5Expenses", typeof(string), typeof(ExpenseViewModel), new PropertyMetadata(null));

        private string _roommate5Expenses;
        public string Roommate5Expenses
        {
            get
            {
                return this._roommate5Expenses;
            }
            set
            {
                this._roommate5Expenses = value;
                NotifyPropertyChanged("Roommate5Expenses");
            }
        }
        
        private ICommand _insertCommand1;
        public ICommand InsertCommand1
        {
            get
            {
                if (_insertCommand1 == null)
                    _insertCommand1 = new RelayCommand(param => AddItem1());
                return _insertCommand1;
            }
        }

        private void AddItem1()
        {

            try
            {
                TextBoxInputValidation(this.Roommate1Expenses, "Roommate1Expenses");
                if (validationErrors.Count == 0 && !string.IsNullOrEmpty(this.Roommate1Expenses))
                {
                    this.Roommate1List.Add(Int32.Parse(this.Roommate1Expenses));
                    CalculateExpensePerPerson();
                    this.Roommate1Expenses = null;
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Input string was not in correct format.",ex);
                MessageBox.Show(ex.Message);
            }


        }

        private ICommand _deleteCommand1;
        public ICommand DeleteCommand1
        {
            get
            {
                if (_deleteCommand1 == null)
                    _deleteCommand1 = new RelayCommand(param => DeleteItem1(param));
                return _deleteCommand1;
            }
        }

        private void DeleteItem1(object param)
        {
            int item=(int)param;
            this.Roommate1List.Remove(item);
            CalculateExpensePerPerson();
        }

        
        Dictionary<string, string> validationErrors = new Dictionary<string, string>();
        private void TextBoxInputValidation(string textboxInput,string key)
        {
            validationErrors.Clear();
            if (!Regex.IsMatch(textboxInput, "^[0-9]*$"))
            {
                validationErrors.Add(key,"Please select valid input, numbers only");
            }
            NotifyPropertyChanged(null);
        }

        private float CalculateFinalAmount(ObservableCollection<int> observableCollection)
        {
            float finalAmount=((float)GetSumOfCollection(observableCollection))-this.TotalPerHead;
            return finalAmount;
        }

        private ICommand _insertCommand2;
        public ICommand InsertCommand2
        {
            get
            {
                if (_insertCommand2 == null)
                    _insertCommand2 = new RelayCommand(param => AddItem2());
                return _insertCommand2;
            }
        }

        private void AddItem2()
        {
            try
            {
                TextBoxInputValidation(this.Roommate2Expenses, "Roommate2Expenses");
                if (validationErrors.Count == 0 && !string.IsNullOrEmpty(this.Roommate2Expenses))
                {
                    this.Roommate2List.Add(Int32.Parse(this.Roommate2Expenses));
                    CalculateExpensePerPerson();
                    this.Roommate2Expenses = null;
                }
                
            }
            catch (Exception ex)
            {
                //throw new Exception("Input string was not in correct format.", ex);
                MessageBox.Show(ex.Message);
            }

        }

        private ICommand _deleteCommand2;
        public ICommand DeleteCommand2
        {
            get
            {
                if (_deleteCommand2 == null)
                    _deleteCommand2 = new RelayCommand(param => DeleteItem2(param));
                return _deleteCommand2;
            }
        }

        private void DeleteItem2(object param)
        {
            int item = (int)param;
            this.Roommate2List.Remove(item);
            CalculateExpensePerPerson();
        }


        private ICommand _insertCommand3;
        public ICommand InsertCommand3
        {
            get
            {
                if (_insertCommand3 == null)
                    _insertCommand3 = new RelayCommand(param => AddItem3());
                return _insertCommand3;
            }
        }

        private void AddItem3()
        {
            try
            {
                TextBoxInputValidation(this.Roommate3Expenses, "Roommate3Expenses");
                if (validationErrors.Count == 0 && !String.IsNullOrEmpty(this.Roommate3Expenses))
                {
                    this.Roommate3List.Add(Int32.Parse(this.Roommate3Expenses));
                    CalculateExpensePerPerson();
                    this.Roommate3Expenses = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private ICommand _deleteCommand3;
        public ICommand DeleteCommand3
        {
            get
            {
                if (_deleteCommand3 == null)
                    _deleteCommand3 = new RelayCommand(param => DeleteItem3(param));
                return _deleteCommand3;
            }
        }

        private void DeleteItem3(object param)
        {
            int item = (int)param;
            this.Roommate3List.Remove(item);
            CalculateExpensePerPerson();
        }


        private ICommand _insertCommand4;
        public ICommand InsertCommand4
        {
            get
            {
                if (_insertCommand4 == null)
                    _insertCommand4 = new RelayCommand(param => AddItem4());
                return _insertCommand4;
            }
        }

        private void AddItem4()
        {
            try
            {
                TextBoxInputValidation(this.Roommate4Expenses, "Roommate4Expenses");
                if (validationErrors.Count == 0 && !string.IsNullOrEmpty(this.Roommate4Expenses))
                {
                    this.Roommate4List.Add(Int32.Parse(this.Roommate4Expenses));
                    CalculateExpensePerPerson();
                    this.Roommate4Expenses = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private ICommand _deleteCommand4;
        public ICommand DeleteCommand4
        {
            get
            {
                if (_deleteCommand4 == null)
                    _deleteCommand4 = new RelayCommand(param => DeleteItem4(param));
                return _deleteCommand4;
            }
        }

        private void DeleteItem4(object param)
        {
            int item = (int)param;
            this.Roommate4List.Remove(item);
            CalculateExpensePerPerson();
        }


        private ICommand _insertCommand5;
        public ICommand InsertCommand5
        {
            get
            {
                if (_insertCommand5 == null)
                    _insertCommand5 = new RelayCommand(param => AddItem5());
                return _insertCommand5;
            }
        }

        private void AddItem5()
        {
            try
            {
                TextBoxInputValidation(this.Roommate5Expenses, "Roommate5Expenses");
                if (validationErrors.Count == 0 && !string.IsNullOrEmpty(this.Roommate5Expenses))
                {
                    this.Roommate5List.Add(Int32.Parse(this.Roommate5Expenses));
                    CalculateExpensePerPerson();
                    this.Roommate5Expenses = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private ICommand _deleteCommand5;
        public ICommand DeleteCommand5
        {
            get
            {
                if (_deleteCommand5 == null)
                    _deleteCommand5 = new RelayCommand(param => DeleteItem5(param));
                return _deleteCommand5;
            }
        }

        private void DeleteItem5(object param)
        {
            int item = (int)param;
            this.Roommate5List.Remove(item);
            CalculateExpensePerPerson();
        }

        private ICommand _finalAmountCommand;
        public ICommand FinalAmountCommand
        {
            get
            {
                if (_finalAmountCommand == null)
                    _finalAmountCommand = new RelayCommand(param => GetFinalAmount());
                return _finalAmountCommand;
            }
        }

        private void GetFinalAmount()
        {
            switch (this.SelectedPeopleNumber)
            {
                case 2:
                    this.FinalExpensePerson1 = CalculateFinalAmount(this.Roommate1List);
                    this.FinalExpensePerson2 = CalculateFinalAmount(this.Roommate2List);
                    break;
                case 3:
                    this.FinalExpensePerson1 = CalculateFinalAmount(this.Roommate1List);
                    this.FinalExpensePerson2 = CalculateFinalAmount(this.Roommate2List);
                    this.FinalExpensePerson3 = CalculateFinalAmount(this.Roommate3List);
                    break;
                case 4:
                    this.FinalExpensePerson1 = CalculateFinalAmount(this.Roommate1List);
                    this.FinalExpensePerson2 = CalculateFinalAmount(this.Roommate2List);
                    this.FinalExpensePerson3 = CalculateFinalAmount(this.Roommate3List);
                    this.FinalExpensePerson4 = CalculateFinalAmount(this.Roommate4List);
                    break;
                case 5:
                    this.FinalExpensePerson1 = CalculateFinalAmount(this.Roommate1List);
                    this.FinalExpensePerson2 = CalculateFinalAmount(this.Roommate2List);
                    this.FinalExpensePerson3 = CalculateFinalAmount(this.Roommate3List);
                    this.FinalExpensePerson4 = CalculateFinalAmount(this.Roommate4List);
                    this.FinalExpensePerson5 = CalculateFinalAmount(this.Roommate5List);
                    break;
                default :
                    Console.WriteLine("Default Value");
                    break;
            }
        }

        private ICommand _exportFileCommand;
        public ICommand ExportFileCommand
        {
            get
            {
                if (_exportFileCommand == null)
                    _exportFileCommand = new RelayCommand(param => ExportToFile((Object[])param));
                return _exportFileCommand;
            }
        }

        private string grpBoxPrsn1Header="Praveen";
        public string GrpBoxPrsn1Header
        {
            get 
            {
                return this.grpBoxPrsn1Header;
            }
            set
            {
                this.grpBoxPrsn1Header = value;
            }
        }

        private void ExportToFile(Object[] obj)
        {
            DataSet ds = new DataSet();
            switch (this.SelectedPeopleNumber)
            {
                case 2:
                    ds.Tables.Add(ConvertListToDataTable(Roommate1List, obj[0].ToString()));
                    ds.Tables.Add(ConvertListToDataTable(Roommate2List, obj[1].ToString()));
                    break;
                case 3:
                    ds.Tables.Add(ConvertListToDataTable(Roommate1List, obj[0].ToString()));
                    ds.Tables.Add(ConvertListToDataTable(Roommate2List, obj[1].ToString()));
                    ds.Tables.Add(ConvertListToDataTable(Roommate3List, obj[2].ToString()));
                    break;
                case 4:
                    ds.Tables.Add(ConvertListToDataTable(Roommate1List, obj[0].ToString()));
                    ds.Tables.Add(ConvertListToDataTable(Roommate2List, obj[1].ToString()));
                    ds.Tables.Add(ConvertListToDataTable(Roommate3List, obj[2].ToString()));
                    ds.Tables.Add(ConvertListToDataTable(Roommate4List, obj[3].ToString()));
                    break;
                case 5:
                    ds.Tables.Add(ConvertListToDataTable(Roommate1List, obj[0].ToString()));
                    ds.Tables.Add(ConvertListToDataTable(Roommate2List, obj[1].ToString()));
                    ds.Tables.Add(ConvertListToDataTable(Roommate3List, obj[2].ToString()));
                    ds.Tables.Add(ConvertListToDataTable(Roommate4List, obj[3].ToString()));
                    ds.Tables.Add(ConvertListToDataTable(Roommate5List, obj[4].ToString()));
                    break;
            }
            //Export(@"E:\\ExpenseReport.xlsx", ds);
            ExportDataSetToExcel(ds);
        }
        private ICommand _resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                    _resetCommand = new RelayCommand(param => ResetList((String)param));
                return _resetCommand;
            }
        }

        private void ResetList(string str)
        {
            switch (str)
            {
                case "List1":
                    this.Roommate1List.Clear();
                    this.FinalExpensePerson1 = 0;
                    CalculateExpensePerPerson();
                    break;
                case "List2":
                    this.Roommate2List.Clear();
                    this.FinalExpensePerson2 = 0;
                    CalculateExpensePerPerson();
                    break;
                case "List3":
                    this.Roommate3List.Clear();
                    this.FinalExpensePerson3 = 0;
                    CalculateExpensePerPerson();
                    break;
                case "List4":
                    this.Roommate4List.Clear();
                    this.FinalExpensePerson4 = 0;
                    CalculateExpensePerPerson();
                    break;
                case "List5":
                    this.Roommate5List.Clear();
                    this.FinalExpensePerson5 = 0;
                    CalculateExpensePerPerson();
                    break;
            }
        }

        

        private void CalculateExpensePerPerson()
        {
            float totalPerHead=0;

            if (this.SelectedPeopleNumber == 2)
            {
                totalPerHead=(GetSumOfCollection(this.Roommate1List) + GetSumOfCollection(this.Roommate2List))/2;
            }
            if (this.SelectedPeopleNumber == 3)
            {
                totalPerHead = (GetSumOfCollection(this.Roommate1List) + GetSumOfCollection(this.Roommate2List) + GetSumOfCollection(this.Roommate3List)) / 3;
            }
            if (this.SelectedPeopleNumber == 4)
            {
                totalPerHead = (GetSumOfCollection(this.Roommate1List) + GetSumOfCollection(this.Roommate2List) + GetSumOfCollection(this.Roommate3List) + GetSumOfCollection(this.Roommate4List)) / 4;
            }
            if (this.SelectedPeopleNumber == 5)
            {
                totalPerHead = (GetSumOfCollection(this.Roommate1List) + GetSumOfCollection(this.Roommate2List) + GetSumOfCollection(this.Roommate3List) + GetSumOfCollection(this.Roommate4List) + GetSumOfCollection(this.Roommate5List)) / 5;
            }

            this.TotalPerHead=totalPerHead;
        }
        private int GetSumOfCollection(ICollection<int> coll)
        {
            int total=0;
            foreach (int item in coll)
            {
                total = total + item;
            }
            return total;
        }

        public float TotalPerHead
        {
            get { return (float)GetValue(TotalPerHeadProperty); }
            set { SetValue(TotalPerHeadProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalPerHead.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalPerHeadProperty =
            DependencyProperty.Register("TotalPerHead", typeof(float), typeof(ExpenseViewModel), new PropertyMetadata(0.0f));



        public float FinalExpensePerson1
        {
            get { return (float)GetValue(FinalExpensePerson1Property); }
            set { SetValue(FinalExpensePerson1Property, value); }
        }

        // Using a DependencyProperty as the backing store for FinalExpensePerson1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FinalExpensePerson1Property =
            DependencyProperty.Register("FinalExpensePerson1", typeof(float), typeof(ExpenseViewModel), new PropertyMetadata(0.0f));



        public float FinalExpensePerson2
        {
            get { return (float)GetValue(FinalExpensePerson2Property); }
            set { SetValue(FinalExpensePerson2Property, value); }
        }

        // Using a DependencyProperty as the backing store for FinalExpensePerson2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FinalExpensePerson2Property =
            DependencyProperty.Register("FinalExpensePerson2", typeof(float), typeof(ExpenseViewModel), new PropertyMetadata(0.0f));



        public float FinalExpensePerson3
        {
            get { return (float)GetValue(FinalExpensePerson3Property); }
            set { SetValue(FinalExpensePerson3Property, value); }
        }

        // Using a DependencyProperty as the backing store for FinalExpensePerson3.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FinalExpensePerson3Property =
            DependencyProperty.Register("FinalExpensePerson3", typeof(float), typeof(ExpenseViewModel), new PropertyMetadata(0.0f));



        public float FinalExpensePerson4
        {
            get { return (float)GetValue(FinalExpensePerson4Property); }
            set { SetValue(FinalExpensePerson4Property, value); }
        }

        // Using a DependencyProperty as the backing store for FinalExpensePerson4.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FinalExpensePerson4Property =
            DependencyProperty.Register("FinalExpensePerson4", typeof(float), typeof(ExpenseViewModel), new PropertyMetadata(0.0f));



        public float FinalExpensePerson5
        {
            get { return (float)GetValue(FinalExpensePerson5Property); }
            set { SetValue(FinalExpensePerson5Property, value); }
        }

        // Using a DependencyProperty as the backing store for FinalExpensePerson5.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FinalExpensePerson5Property =
            DependencyProperty.Register("FinalExpensePerson5", typeof(float), typeof(ExpenseViewModel), new PropertyMetadata(0.0f));

        #region Validation
        public string Error
        {
            get
            {
                return this[string.Empty];
            }
        }
        public string this[string currectname]
        {
            get
            {
                string result = null;
                if (currectname == "SelectedPeopleNumber")
                {
                    if (this.SelectedPeopleNumber == 0)
                    {
                        result = "Please select number of people";
                        return result;
                    }
                }
                
                if(currectname == "Roommate1Expenses")
                {
                    if (string.IsNullOrEmpty(Roommate1Expenses))
                    {
                        result = "It can't be empty";
                        return result;
                    }
                    if (this.Roommate1Expenses != null)
                    {
                        if (validationErrors.ContainsKey(currectname))
                        {
                            return validationErrors[currectname];
                        }
                    }
                }
                
                
                if(currectname == "Roommate2Expenses")
                {
                    if (string.IsNullOrEmpty(Roommate2Expenses))
                    {
                        result = "It can't be empty";
                        return result;
                    }
                    if (this.Roommate2Expenses != null)
                    {
                        if (validationErrors.ContainsKey(currectname))
                        {
                            return validationErrors[currectname];
                        }
                    }
                }
                if (currectname == "Roommate3Expenses")
                {
                    if (string.IsNullOrEmpty(Roommate3Expenses))
                    {
                        result = "It can't be empty";
                        return result;
                    }
                    if (this.Roommate3Expenses != null)
                    {
                        if (validationErrors.ContainsKey(currectname))
                        {
                            return validationErrors[currectname];
                        }
                    }
                }
                if (currectname == "Roommate4Expenses")
                {
                    if (string.IsNullOrEmpty(Roommate4Expenses))
                    {
                        result = "It can't be empty";
                        return result;
                    }
                    if (this.Roommate4Expenses != null)
                    {
                        if (validationErrors.ContainsKey(currectname))
                        {
                            return validationErrors[currectname];
                        }
                    }
                }
                if (currectname == "Roommate5Expenses")
                {
                    if (string.IsNullOrEmpty(Roommate5Expenses))
                    {
                        result = "It can't be empty";
                        return result;
                    }
                    if (this.Roommate5Expenses != null)
                    {
                        if (validationErrors.ContainsKey(currectname))
                        {
                            return validationErrors[currectname];
                        }
                    }
                }
                return null;
            }
        }

        private bool isTextBox1Enabled=false;
        public bool IsTextBox1Enabled 
        {
            get
            {
                return this.isTextBox1Enabled;
            } 
            set
            {
                this.isTextBox1Enabled=value;
                NotifyPropertyChanged("IsTextBox1Enabled");
            }
        }
        
        private bool isTextBox2Enabled = false;
        public bool IsTextBox2Enabled
        {
            get
            {
                return this.isTextBox2Enabled;
            }
            set
            {
                this.isTextBox2Enabled = value;
                NotifyPropertyChanged("IsTextBox2Enabled");
            }
        }
        
        private bool isTextBox3Enabled = false;
        public bool IsTextBox3Enabled
        {
            get
            {
                return this.isTextBox3Enabled;
            }
            set
            {
                this.isTextBox3Enabled = value;
                NotifyPropertyChanged("IsTextBox3Enabled");
            }
        }

        private bool isTextBox4Enabled = false;
        public bool IsTextBox4Enabled
        {
            get
            {
                return this.isTextBox4Enabled;
            }
            set
            {
                this.isTextBox4Enabled = value;
                NotifyPropertyChanged("IsTextBox4Enabled");
            }
        }

        private bool isTextBox5Enabled = false;
        public bool IsTextBox5Enabled
        {
            get
            {
                return this.isTextBox5Enabled;
            }
            set
            {
                this.isTextBox5Enabled = value;
                NotifyPropertyChanged("IsTextBox5Enabled");
            }
        }

        private void TextBoxValidation()
        {
            switch (this.SelectedPeopleNumber)
            {
                case 2:
                    this.IsTextBox1Enabled = this.IsTextBox2Enabled = true;
                    this.IsTextBox3Enabled = this.IsTextBox4Enabled = this.IsTextBox5Enabled = false;
                    break;
                case 3:
                    this.IsTextBox1Enabled = this.IsTextBox2Enabled = this.IsTextBox3Enabled=true;
                    this.IsTextBox4Enabled = this.IsTextBox5Enabled = false;
                    break;
                case 4:
                    this.IsTextBox1Enabled = this.IsTextBox2Enabled = this.IsTextBox3Enabled=this.IsTextBox4Enabled=true;
                    this.IsTextBox5Enabled = false;
                    break;
                case 5:
                    this.IsTextBox1Enabled = this.IsTextBox2Enabled = this.IsTextBox3Enabled = this.IsTextBox4Enabled =this.IsTextBox5Enabled= true;
                    break;
            }
        }
        #endregion

        private System.Data.DataTable ConvertListToDataTable(ObservableCollection<int> list,string colName)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add(colName);
            foreach (int num in list)
            {
                dt.Rows.Add(num);
            }
            return dt;
        }
        
        private void ExportDataSetToExcel(DataSet ds)
        {
            try
            {
                //Creae an Excel application instance
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                object misValue = System.Reflection.Missing.Value;
                //Create an Excel workbook instance and open it from the predefined location
                Microsoft.Office.Interop.Excel.Workbook excelWorkBook = excelApp.Workbooks.Add(misValue);
                Microsoft.Office.Interop.Excel.Worksheet excelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);
                excelWorkSheet.Name = "Expense Report "+DateTime.Now.ToString("MMM");
                
                int i = 2, k = 1;
                List<int> listRowCount = new List<int>();
                foreach (System.Data.DataTable table in ds.Tables)
                {
                    listRowCount.Add(table.Rows.Count);
                    excelWorkSheet.Cells[2, i] = table.Columns[0].ColumnName;
                    i += 2;
                    for (int j = 0; j < table.Rows.Count; j++)
                    {
                        excelWorkSheet.Cells[j + 3, k + 1] = table.Rows[j].ItemArray[0].ToString();
                    }
                    k += 2;
                }
                excelWorkSheet.Cells[1, 1] = DateTime.Now.ToString("dd-MMM-yyyy");
                excelWorkSheet.Cells[1, k] = "Per Head: " + this.TotalPerHead;
                int l=listRowCount.Max();
                int m = 2,p=0;
                float[] finalExpense = new float[] { FinalExpensePerson1, FinalExpensePerson2, FinalExpensePerson3, FinalExpensePerson4, FinalExpensePerson5 };
                foreach (System.Data.DataTable table in ds.Tables)
                {
                    excelWorkSheet.Cells[l+4, m] = finalExpense[p++];
                    m += 2;
                }
                excelWorkSheet.Range["A1", "A2"].EntireRow.Font.Bold = true;
                excelWorkSheet.Columns.AutoFit();
                char asciiChars = Convert.ToChar(k+'A'-1);
                int totalRow=l+4;
                string range = "A1:" + asciiChars + "" + totalRow;
                FormatAsTable(excelWorkSheet, range, excelWorkSheet.Name);
                CreateCellBorder(excelWorkSheet,totalRow+1,k);
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.InitialDirectory = @"C:\";
                saveDlg.Filter = "Excel 2010 (*.xlsx)|*.xlsx|Excel (*.xls)|*.xls";
                saveDlg.FilterIndex = 0;
                saveDlg.RestoreDirectory = true;
                saveDlg.Title = "Export Excel File To";
                if (saveDlg.ShowDialog() == true)
                {
                    string path = saveDlg.FileName;
                    excelWorkBook.SaveCopyAs(path);
                    excelWorkBook.Saved = true;
                    excelWorkBook.Close(true, misValue, misValue);
                    excelApp.Quit();
                    MessageBox.Show("Excel file created");
                }
                releaseObject(excelWorkSheet);
                releaseObject(excelWorkBook);
                releaseObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error accessing Excel: " + ex.ToString());
            }

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        
        private void FormatAsTable(Microsoft.Office.Interop.Excel.Worksheet sheet,string tableRange,string sheetName)
        {
            Microsoft.Office.Interop.Excel.Range range = sheet.get_Range(tableRange);
            sheet.ListObjects.Add(XlListObjectSourceType.xlSrcRange, range, System.Type.Missing, XlYesNoGuess.xlNo, System.Type.Missing).Name = sheetName;
            sheet.ListObjects.get_Item(sheetName).TableStyle = "TableStyleMedium1";
        }
        private void CreateCellBorder(Microsoft.Office.Interop.Excel.Worksheet sheet, int maxRow, int maxCol)
        {
            for (int i = 2; i < maxCol; i+=2)
            {
                var platypusRange = sheet.Range[sheet.Cells[3, i], sheet.Cells[maxRow, i]];
                Borders border = platypusRange.Borders;
                border[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                border.Weight = 2d;
                
            }
            var platypusRangeHeader = sheet.Range[sheet.Cells[3, 1], sheet.Cells[3, maxCol]];
            BorderAround(platypusRangeHeader);
            var platypusRangeFooter = sheet.Range[sheet.Cells[maxRow, 1], sheet.Cells[maxRow, maxCol]];
            BorderAround(platypusRangeFooter);
            sheet.Range[sheet.Cells[3, 1], sheet.Cells[3, maxCol]].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        private void BorderAround(Range range)
        {
            Borders borders = range.Borders;
            borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            borders.Weight = 3d;
            //borders.Color = colour;
            //borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlLineStyleNone;
            borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlLineStyleNone;
            borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
            borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
            borders = null;
        }
    }
}
