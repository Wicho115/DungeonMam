using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalMessenger
{
    private class DatosEvento
    {
        public List<Callback> callbacks = new List<Callback>();

        public List<Callback> temp = new List<Callback>();

        public bool isInvoking;
    }

    private static IDictionary<string, DatosEvento> tablaEventos = new Dictionary<string, DatosEvento>(ComparerLib.stringComparer);

    public static void AddListener(string tipoEvento, Callback manager)
    {
        lock (tablaEventos)
        {
            if(!tablaEventos.TryGetValue(tipoEvento, out var evento))
            {
                evento = new DatosEvento();
                tablaEventos.Add(tipoEvento, evento);
            }

            evento.callbacks.Add(manager);
        }
    }

    public static void RemoveListener(string tipoEvento, Callback manager)
    {
        lock (tablaEventos)
        {
            if (!tablaEventos.TryGetValue(@tipoEvento, out var evento)) return;

            int index = evento.callbacks.IndexOf(manager);
            if (index < 0) return;

            evento.callbacks[index] = evento.callbacks[evento.callbacks.Count - 1];
            evento.callbacks.RemoveAt(evento.callbacks.Count - 1);
        }
    }

    public static void FireEvent(string tipoEvento)
    {
        lock (tablaEventos)
        {
            if (!tablaEventos.TryGetValue(tipoEvento, out var evento)) return;
            if (evento.isInvoking) throw new System.Exception("No se puede invocar varias veces el mismo evento");
            evento.isInvoking = true;
            evento.temp.AddRange(evento.callbacks);
            for (int i = 0; i < evento.temp.Count; i++)
            {
                evento.temp[i]?.Invoke();
            }

            evento.temp.Clear();
            evento.isInvoking = false;
        }
    }
}

public static class GlobalMessenger<T>
{
    private class DatosEvento
    {
        public List<Callback<T>> callbacks = new List<Callback<T>>();

        public List<Callback<T>> temp = new List<Callback<T>>();

        public bool isInvoking;
    }

    private static IDictionary<string, DatosEvento> tablaEventos = new Dictionary<string, DatosEvento>(ComparerLib.stringComparer);

    public static void AddListener(string tipoEvento, Callback<T> manager)
    {
        lock (tablaEventos)
        {
            if (!tablaEventos.TryGetValue(tipoEvento, out var evento))
            {
                evento = new DatosEvento();
                tablaEventos.Add(tipoEvento, evento);
            }

            evento.callbacks.Add(manager);
        }
    }

    public static void RemoveListener(string tipoEvento, Callback<T> manager)
    {
        lock (tablaEventos)
        {
            if (!tablaEventos.TryGetValue(@tipoEvento, out var evento)) return;

            int index = evento.callbacks.IndexOf(manager);
            if (index < 0) return;

            evento.callbacks[index] = evento.callbacks[evento.callbacks.Count - 1];
            evento.callbacks.RemoveAt(evento.callbacks.Count - 1);
        }
    }

    public static void FireEvent(string tipoEvento, T arg1)
    {
        lock (tablaEventos)
        {
            if (!tablaEventos.TryGetValue(tipoEvento, out var evento)) return;
            if (evento.isInvoking) throw new System.Exception("No se puede invocar varias veces el mismo evento");
            evento.isInvoking = true;
            evento.temp.AddRange(evento.callbacks);
            for (int i = 0; i < evento.temp.Count; i++)
            {
                evento.temp[i]?.Invoke(arg1);
            }

            evento.temp.Clear();
            evento.isInvoking = false;
        }
    }
}
public static class GlobalMessenger<T1, T2>
{
    private class DatosEvento
    {
        public List<Callback<T1, T2>> callbacks = new List<Callback<T1, T2>>();

        public List<Callback<T1, T2>> temp = new List<Callback<T1, T2>>();

        public bool isInvoking;
    }

    private static IDictionary<string, DatosEvento> tablaEventos = new Dictionary<string, DatosEvento>(ComparerLib.stringComparer);

    public static void AddListener(string tipoEvento, Callback<T1, T2> manager)
    {
        lock (tablaEventos)
        {
            if (!tablaEventos.TryGetValue(tipoEvento, out var evento))
            {
                evento = new DatosEvento();
                tablaEventos.Add(tipoEvento, evento);
            }

            evento.callbacks.Add(manager);
        }
    }

    public static void RemoveListener(string tipoEvento, Callback<T1, T2> manager)
    {
        lock (tablaEventos)
        {
            if (!tablaEventos.TryGetValue(@tipoEvento, out var evento)) return;

            int index = evento.callbacks.IndexOf(manager);
            if (index < 0) return;

            evento.callbacks[index] = evento.callbacks[evento.callbacks.Count - 1];
            evento.callbacks.RemoveAt(evento.callbacks.Count - 1);
        }
    }

    public static void FireEvent(string tipoEvento, T1 arg1, T2 arg2)
    {
        lock (tablaEventos)
        {
            if (!tablaEventos.TryGetValue(tipoEvento, out var evento)) return;
            if (evento.isInvoking) throw new System.Exception("No se puede invocar varias veces el mismo evento");
            evento.isInvoking = true;
            evento.temp.AddRange(evento.callbacks);
            for (int i = 0; i < evento.temp.Count; i++)
            {
                evento.temp[i]?.Invoke(arg1, arg2);
            }

            evento.temp.Clear();
            evento.isInvoking = false;
        }
    }
}
