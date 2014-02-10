using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EventLife
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Per abilitare il supporto query per le azioni con tipo restituito IQueryable o IQueryable<T>, rimuovere il commento dalla seguente riga di codice.
            // Per evitare l'elaborazione di query dannose o impreviste, utilizzare le impostazioni di convalida definite in QueryableAttribute per convalidare le query in ingresso.
            // Per ulteriori informazioni, visitare il sito Web all'indirizzo http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}