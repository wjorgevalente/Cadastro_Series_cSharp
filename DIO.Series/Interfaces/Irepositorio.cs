using System;
using System.Collections.Generic;
using DIO.Series;



namespace DIO.Series.Interfaces
{
    public interface Irepositorio<T>
    {
        List<T> Lista();

        T RetornaPorId(int id);

        void Insere(T entidade);

        void Excluir(int id);

        void Atualizar(int id, T entidade);

        int ProximoId();
    }
}