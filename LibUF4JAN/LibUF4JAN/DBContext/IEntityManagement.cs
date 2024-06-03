using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SakilaDSEngine
{
    /// <summary>
    /// Interficie manipulació bàsica CRUD sobre entitats (classes que representaran
    /// les dades d'una taula) i DataSet.
    /// </summary>
    /// <typeparam name="T">
    /// T representa el tipus entitat. p.e. Customer de la bdd Pagila
    /// </typeparam>
    /// <typeparam name="U">
    /// U representa el tipus clau primària, per aquells mètodes que 
    /// necessiten clau primària, ja que en alguns casos pot ser un enter,
    /// en d'altres un string, etc.
    /// </typeparam>
    public interface IEntityManagement<T, U>
    {
        /// <summary>
        /// Mètode per obtenir una nova instància (buida) de l'entitat
        /// </summary>
        /// <returns> Retorna un objecte del tipus entitat</returns>
        T GetInstance();

        /// <summary>
        /// Mètode per obtenir totes les dades d'una entitat (taula).
        /// </summary>
        /// <returns>Retorna una llista d'objectes tipus entitat</returns>
        List<T> GetData();

        /// <summary>
        /// Mètode per obtenir les dades d'una entitat a partir de la clau primària
        /// </summary>
        /// <param name="Id"> Clau primària, el tipus dependrà de la primary key 
        /// de la taula associada a l'entitat</param>
        /// <returns> Retorna un objecte tipus entitat</returns>
        T GetDataById(U Id);

        /// <summary>
        /// Mètode per inserir les dades d'una nova entitat a la taula associada
        /// </summary>
        /// <param name="data">Objecte tipus entitat que es donarà d'alta</param>
        /// <returns>Retorna un booleà indicant si l'operació ha anat be</returns>
        bool AddData(T data);

        /// <summary>
        /// Mètode per eliminar les dades d'una entitat existent a partir de la clau primària
        /// </summary>
        /// <param name="Id"> Clau primària, el tipus dependrà de la primary key 
        /// de la taula associada a l'entitat</param>
        /// <returns>Retorna un booleà indicant si l'operació ha anat be</returns>
        bool RemoveDataById(U Id);

        /// <summary>
        /// Mètode per actualitzar les dades d'una entitat existent a partir de la clau primària
        /// </summary>
        /// <param name="Id">Clau primària, el tipus dependrà de la primary key 
        /// de la taula associada a l'entitat</param>
        /// <param name="data">Objecte tipus entitat modificat</param>
        /// <returns>Retorna un booleà indicant si l'operació ha anat be</returns>
        bool UpdateData(U Id, T data);

    }
}
