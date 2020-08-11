namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using ViewModels.Custom;
    using ViewModels.WCF;

    [ServiceContract]
    public interface IMobileAppWebServices
    {
        [OperationContract]
        TrainServiceDetail ServiceDetail(string number);

        [OperationContract]
        IEnumerable<CrewService> GetUserFinishedTrains(string azureId);

        [OperationContract]
        IEnumerable<CrewService> GetUserPendingTrains(string azureId);

        [OperationContract]
        //[XmlSerializerFormat]
        bool ReportPosition(decimal lat, decimal lng, int trainId);

        [OperationContract]
        //[XmlSerializerFormat]
        void ReportNews(string type, string description, int trainId);

        [OperationContract]
        //[XmlSerializerFormat]
        bool CheckServiceAvailability(decimal lat, decimal lng, int trainId, string azureId);

        [OperationContract]
        //[XmlSerializerFormat]
        bool StartService(int trainId, string azureId, int id_actividad);

        [OperationContract]
        bool StopService(int trainId);

        [OperationContract]
        bool RegisterDeviceID(string azureId, string dispositivoID);

        [OperationContract]
        void RegisterIdAzure(string email, string azureId);

        [OperationContract]
        int startWorkDay(string azureId);

        [OperationContract]
        void stopWorkDay(int Id_Jornada);

        [OperationContract]
        bool GetUserPendingWorkDay(string azureId);



        //[OperationContract]
        //bool StopWorkDay(string azureId);


        //[OperationContract]
        //bool StartWorkDay(string azureId, DateTime horaInicio, DateTime horaFin, int idTren);
    }
}