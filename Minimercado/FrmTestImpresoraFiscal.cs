using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HasarArgentina;

namespace Minimercado
{
    public partial class FrmTestImpresoraFiscal : Form
    {
        public FrmTestImpresoraFiscal()
        {
            InitializeComponent();
        }

        HasarArgentina.ImpresoraFiscalRG3561 ocxHasar;
        private void TestHasar_Load(object sender, EventArgs e)
        {


        }

        private void btnFechaHora_Click(object sender, EventArgs e)
        {
            try {

                string texto = "FECHA/HORA\n";
                RespuestaConsultarFechaHora res = new RespuestaConsultarFechaHora();
                res = ocxHasar.ConsultarFechaHora();

                texto += "Fecha Actual: " + res.Fecha + "\n";
                texto += "Hora Actual: " + res.Hora + "\n";
                MessageBox.Show(texto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción --> " + ex.Message);
            }

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            conectar();
        }

        private void conectar()
        {
            try
            {

                ocxHasar = new HasarArgentina.ImpresoraFiscalRG3561();

                bool z = false;
                bool factura = false;
                bool cancelar = true;
                bool dnf = false;
                bool estado = true;
                Console.Out.WriteLine("Hasar SAIC");
                Console.Out.WriteLine("Version del protocolo fiscal: " + 0);

                //HasarArgentina.RespuestaConsultarConfiguracionRed resp = new RespuestaConsultarConfiguracionRed();
                //resp = p.ConsultarConfiguracionRed();
                //string rta = resp.DireccionIP;
                ocxHasar.Conectar("127.0.0.1", 6500);
                //p.establecerTiempoDeEsperaConexion(10000);
                //p.establecerTiempoDeEsperaLecturaEscritura(25000);
                //p.archivoRegistro("C:\\Temp\\VCSharp\\ConsoleApplication1.log");
                //p += new hfl.argentina.HasarImpresoraFiscalRG3561.setStatusPinter(p_eventoImpresora); // getstatus
                //p.eventoComandoEnProceso += new hfl.argentina.HasarImpresoraFiscalRG3561.setComandoEnProceso(p_eventoComandoEnProceso);
                //p.eventoComandoProcesado += new hfl.argentina.HasarImpresoraFiscalRG3561.setComandoProcesado(p_eventoComandoProcesado);


                try
                {
                    HasarArgentina.RespuestaConsultarEstado r = ocxHasar.ConsultarEstado();
                    Console.Out.WriteLine("Modo Entrenamiento?:        " + r.EstadoAuxiliar.ModoEntrenamiento.ToString());
                    Console.Out.WriteLine("Estado Interno:            " + r.EstadoInterno);
                    Console.Out.WriteLine("Cantidad Cancelados:       " + r.CantidadCancelados);
                    Console.Out.WriteLine("Cantidad Emitidos:         " + r.CantidadEmitidos);
                    Console.Out.WriteLine("Codigo Comprobante:        " + r.CodigoComprobante);
                    Console.Out.WriteLine("Comprobante en Curso:      " + r.ComprobanteEnCurso);
                    Console.Out.WriteLine("Numero Ultimo Comprobante: " + r.NumeroUltimoComprobante);
                    string texto = "CONECTADO CON ÉXITO\n";

                    texto += "Modo Entrenamiento:        " + r.EstadoAuxiliar.ModoEntrenamiento.ToString() + "\n";
                    texto += "Estado Interno:            " + r.EstadoInterno + "\n";
                    texto += "Cantidad Cancelados:       " + r.CantidadCancelados + "\n";
                    texto += "Cantidad Emitidos:         " + r.CantidadEmitidos + "\n";
                    texto += "Codigo Comprobante:        " + r.CodigoComprobante + "\n";
                    texto += "Comprobante en Curso:      " + r.ComprobanteEnCurso + "\n";
                    texto += "Numero Ultimo Comprobante: " + r.NumeroUltimoComprobante + "\n";
                    MessageBox.Show(texto);
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción --> " + ex.Message);
            }
        }

        private void btnCierreZ_Click(object sender, EventArgs e)
        {
            try
            {

                string texto = "CIERRE Z\n";
                RespuestaCerrarJornadaFiscal res = new RespuestaCerrarJornadaFiscal();
                CerrarJornadaFiscalZ zeta = new CerrarJornadaFiscalZ();
                res = ocxHasar.CerrarJornadaFiscal(TipoReporte.ReporteZ);
                zeta = res.Z;

                texto += "Cierre Z Nº =[" + zeta.Numero + "]\n";
                texto += "Fecha del Cierre        =[" + zeta.Fecha + "]\n";
                texto += "DF Emitidos             =[" + zeta.DF_CantidadEmitidos + "]\n";
                texto += "DF Cancelados           =[" + zeta.DF_CantidadCancelados + "]\n";
                texto += "DF Total                =[" + zeta.DF_Total + "]\n";
                texto += "DF Total Gravado        =[" + zeta.DF_TotalGravado + "]\n";
                texto += "DF Total No Gravado     =[" + zeta.DF_TotalNoGravado + "]\n";
                texto += "DF Total Exento         =[" + zeta.DF_TotalExento + "]\n";
                texto += "DF Total IVA            =[" + zeta.DF_TotalIVA + "]\n";
                texto += "DF Total Otros Tributos =[" + zeta.DF_TotalTributos + "]\n";
                texto += "NC Emitidas             =[" + zeta.NC_CantidadEmitidos + "]\n";
                texto += "NC Canceladas           =[" + zeta.NC_CantidadCancelados + "]\n";
                texto += "NC Total                =[" + zeta.NC_Total + "]\n";
                texto += "NC Total Gravado        =[" + zeta.NC_TotalGravado + "]\n";
                texto += "NC Total No Gravado     =[" + zeta.NC_TotalNoGravado + "]\n";
                texto += "NC Total Exento         =[" + zeta.NC_TotalExento + "]\n";
                texto += "NC Total IVA            =[" + zeta.NC_TotalIVA + "]\n";
                texto += "NC Total Otros Tributos =[" + zeta.NC_TotalTributos + "]\n";
                texto += "DNFH Emitidos           =[" + zeta.DNFH_CantidadEmitidos + "]\n";
                texto += "DNFH Total              =[" + zeta.DNFH_Total + "]\n";

                MessageBox.Show(texto);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción --> " + ex.Message);
            }
        }

        private void btnFacturaB_Click(object sender, EventArgs e)
        {
            try
            {

                RespuestaAbrirDocumento respAbrir = new RespuestaAbrirDocumento();

                ocxHasar.CargarDatosCliente("Consumidor Final", "99999999995", TiposDeResponsabilidadesCliente.Monotributo, TiposDeDocumentoCliente.TipoCUIT, "-","","","");
                respAbrir = ocxHasar.AbrirDocumento(TiposComprobante.FacturaB);

                decimal PrecioVta = 125m;
                double importe = (double)PrecioVta/1.21;
                double cantidad = 1;
                double alicuotaIva =21;
                double magnitudImpuestoInterno = 0;
                ocxHasar.ImprimirItem("Item 1", cantidad, importe, CondicionesIVA.Gravado, alicuotaIva, ModosDeMonto.ModoSumaMonto, ModosDeImpuestosInternos.IIVariablePorcentual, magnitudImpuestoInterno, ModosDeDisplay.DisplayNo, ModosDePrecio.ModoPrecioBase, 1, "7791234500001", "00001", UnidadesMedida.Unidad);

                ocxHasar.CerrarDocumento();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción --> " + ex.Message);
            }
        }

        private void btnNotaCreditoB_Click(object sender, EventArgs e)
        {
            try
            {
                RespuestaAbrirDocumento resAbrir = new RespuestaAbrirDocumento();

                ocxHasar.CargarDatosCliente("Consumidor Final", "99999999995", TiposDeResponsabilidadesCliente.Monotributo, TiposDeDocumentoCliente.TipoCUIT, "-", "", "", "");
                resAbrir = ocxHasar.AbrirDocumento(TiposComprobante.NotaDeCreditoB);

                decimal PrecioVta = 2706749.7m;
                double importe = (double)PrecioVta / 1.21;
                double cantidad = 1;
                double alicuotaIva = 21;
                double magnitudImpuestoInterno = 0;
                ocxHasar.ImprimirItem("Anulacion F-B-00000022", cantidad, importe, CondicionesIVA.Gravado, alicuotaIva, ModosDeMonto.ModoSumaMonto, ModosDeImpuestosInternos.IIVariablePorcentual, magnitudImpuestoInterno, ModosDeDisplay.DisplayNo, ModosDePrecio.ModoPrecioBase, 1, "7791234500001", "00001", UnidadesMedida.Unidad);

                ocxHasar.CerrarDocumento();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción --> " + ex.Message);
            }
        }

        private void btnFacturaA_Click(object sender, EventArgs e)
        {
            try
            {

                RespuestaAbrirDocumento respAbrir = new RespuestaAbrirDocumento();

                ocxHasar.CargarDatosCliente("Cliente IVA Inscripto", "99999999995", TiposDeResponsabilidadesCliente.ResponsableInscripto, TiposDeDocumentoCliente.TipoCUIT, "Domicilio Cliente", "", "", "");
                respAbrir = ocxHasar.AbrirDocumento(TiposComprobante.TiqueFacturaA);

                decimal PrecioVta = 125m;
                double importe = (double)PrecioVta / 1.21;
                double cantidad = 1;
                double alicuotaIva = 21;
                double magnitudImpuestoInterno = 0;
                ocxHasar.ImprimirItem("Item 1", cantidad, importe, CondicionesIVA.Gravado, alicuotaIva, ModosDeMonto.ModoSumaMonto, ModosDeImpuestosInternos.IIVariablePorcentual, magnitudImpuestoInterno, ModosDeDisplay.DisplayNo, ModosDePrecio.ModoPrecioBase, 1, "7791234500001", "00001", UnidadesMedida.Unidad);

                ocxHasar.CerrarDocumento();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción --> " + ex.Message);
            }
        }

        private void btnNotaCreditoA_Click(object sender, EventArgs e)
        {
            try
            {
                RespuestaAbrirDocumento resAbrir = new RespuestaAbrirDocumento();

                ocxHasar.CargarDatosCliente("Cliente IVA Inscripto", "99999999995", TiposDeResponsabilidadesCliente.ResponsableInscripto, TiposDeDocumentoCliente.TipoCUIT, "Domicilio Cliente", "", "", "");
                resAbrir = ocxHasar.AbrirDocumento(TiposComprobante.NotaDeCreditoA);

                decimal PrecioVta = 125m;
                double importe = (double)PrecioVta / 1.21;
                double cantidad = 1;
                double alicuotaIva = 21;
                double magnitudImpuestoInterno = 0;
                ocxHasar.ImprimirItem("Item 1", cantidad, importe, CondicionesIVA.Gravado, alicuotaIva, ModosDeMonto.ModoSumaMonto, ModosDeImpuestosInternos.IIVariablePorcentual, magnitudImpuestoInterno, ModosDeDisplay.DisplayNo, ModosDePrecio.ModoPrecioBase, 1, "7791234500001", "00001", UnidadesMedida.Unidad);

                ocxHasar.CerrarDocumento();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción --> " + ex.Message);
            }
        }

        private void btnReimprime_Click(object sender, EventArgs e)
        {
            try
            {
                RespuestaPedirReimpresion res = new RespuestaPedirReimpresion();
                res= ocxHasar.PedirReimpresion();
                MessageBox.Show(res.NumeroDeCopia.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción --> " + ex.Message);
            }

        }

        private void btnEstados_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    HasarArgentina.RespuestaConsultarEstado r = ocxHasar.ConsultarEstado();

                    string texto = "CONECTADO CON ÉXITO\n";

                    texto += "Modo Entrenamiento:           " + r.EstadoAuxiliar.ModoEntrenamiento.ToString() + "\n";
                    texto += "Estado Interno:               " + r.EstadoInterno + "\n";
                    texto += "Código Comprobante:           " + r.CodigoComprobante + "\n";
                    texto += "Comprobante en Curso:         " + r.ComprobanteEnCurso + "\n";
                    texto += "Numero Ultimo Comprobante:    " + r.NumeroUltimoComprobante + "\n";
                    texto += "Último Comprobante Cancelado: " + r.EstadoAuxiliar.UltimoComprobanteFueCancelado + "\n";
                    texto += "Comprobantes Emitidos:        " + r.CantidadEmitidos + "\n";
                    texto += "Comprobantes Cancelados:      " + r.CantidadCancelados + "\n";
                    texto += "Memoria Auditoría Casi LLena: " + r.EstadoAuxiliar.MemoriaAuditoriaCasiLlena + "\n";
                    texto += "Memoria Auditoría Llena:      " + r.EstadoAuxiliar.MemoriaAuditoriaLlena + "\n";
                    MessageBox.Show(texto);
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción --> " + ex.Message);
            }
        }

        private void btnUltimoEstado_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    HasarArgentina.EstadoFiscal r = ocxHasar.ObtenerUltimoEstadoFiscal();

                    string texto = "CONECTADO CON ÉXITO\n";

                    texto += "Documento Abierto:            " + r.DocumentoAbierto + "\n";
                    texto += "Documento Fiscal Abierto      " + r.DocumentoFiscalAbierto + "\n";
                    texto += "Error Aritmético:             " + r.ErrorAritmetico + "\n";
                    texto += "Error Ejecución:              " + r.ErrorEjecucion + "\n";
                    texto += "Error Estado:                 " + r.ErrorEstado + "\n";
                    texto += "Error General:                " + r.ErrorGeneral + "\n";
                    texto += "Error Memoria Auditoría:      " + r.ErrorMemoriaAuditoria + "\n";
                    texto += "Error Memoria Fiscal:         " + r.ErrorMemoriaFiscal + "\n";
                    MessageBox.Show(texto);
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción --> " + ex.Message);
            }
        }

        private void btnPrimerBloque_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaIni = new DateTime(dtpFechaIni.Value.Year, dtpFechaIni.Value.Month, dtpFechaIni.Value.Day, 0, 0, 0);
                DateTime fechaFin = new DateTime(dtpFechaFin.Value.Year, dtpFechaFin.Value.Month, dtpFechaFin.Value.Day, 23, 59, 59);
                RespuestaObtenerPrimerBloqueReporteElectronico res= ocxHasar.ObtenerPrimerBloqueReporteElectronico(fechaIni, fechaFin, TiposReporteAFIP.ReporteAFIPCompleto);
                Logger.Log.LogInFile(res.Informacion, "PrimerReporte.log");
                Logger.Log.LogInFile("----", "PrimerReporte.log");
                Logger.Log.LogInFile(res.Registro.ToString(), "PrimerReporte.log");
                IdentificadorBloque ib = res.Registro;
                Logger.Log.LogInFile(ib.ToString(), "PrimerReporte.log");
                Logger.Log.LogInFile("****", "PrimerReporte.log");
                MessageBox.Show("Finalizado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
