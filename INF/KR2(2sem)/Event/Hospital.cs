using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf107_2_.KR2_2sem_.Event
{
    public class Hospital
    {
        List<Doctor> doctors = new List<Doctor>(new Doctor[] { new Doctor { Name = "Амир" } });
        List<Patient> patients = new List<Patient>();
        List<Nurse> nurses = new List<Nurse>(new Nurse[] { new Nurse { Name = "Иванова" } });
        public delegate void HospitalHandlerPatient(Patient patient);
        public delegate void HospitalHandlerNurse(Patient patient, Nurse nurse);
        public delegate void HospitalHandlerDoctor(Patient patient, Doctor doctor);
        public event HospitalHandlerPatient ExecuteEventPatient;
        public event HospitalHandlerNurse ExecuteEventNurse;
        public event HospitalHandlerDoctor ExecuteEventDoctor;
        public Hospital()
        {
            ExecuteEventPatient += PatientAdded;
            ExecuteEventNurse += PatientAccepted;
            ExecuteEventDoctor += PatientWatched;
        }
        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
            ExecuteEventPatient?.Invoke(patient);
            AcceptPatient(patient, nurses[0]);
            WatchPatient(patient, doctors[0]);
        }
        public void AcceptPatient(Patient patient, Nurse nurse)
        {
            patients.Add(patient);
            ExecuteEventNurse?.Invoke(patient, nurse);
        }
        public void WatchPatient(Patient patient, Doctor doctor)
        {
            patients.Add(patient);
            ExecuteEventDoctor?.Invoke(patient, doctor);
        }
        private void PatientAdded(Patient patient)
        {
            Console.WriteLine("Пациент {0} поступил в больницу.", patient.Name);
        }
        private void PatientAccepted(Patient patient, Nurse nurse)
        {
            Console.WriteLine("Медсестара {0} оформила пациента {1}.", nurse.Name, patient.Name);
        }
        private void PatientWatched(Patient patient, Doctor doctor)
        {
            Console.WriteLine("Доктор {0} осмотрел пациента {1}.", doctor.Name, patient.Name);
        }
    }
}
