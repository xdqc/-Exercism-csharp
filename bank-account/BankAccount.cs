using System;
using System.Threading.Tasks;

public class BankAccount
{

    float _balance = 0;
    bool _open = false;

    public void Open()
    {
        _open = true;
    }

    public void Close()
    {
        _open = false;
    }

    public float Balance
    {
        get
        {
            if (_open)
            {
                return _balance;
            }
            else{
                throw new InvalidOperationException("Cannot check balance on a closed bank account.");
            }
        }
    }

    public void UpdateBalance(float change)
    {
        if (_open)
        {   
            lock (this)
            {
                _balance += change;  
            }
            
        }
    }
}
