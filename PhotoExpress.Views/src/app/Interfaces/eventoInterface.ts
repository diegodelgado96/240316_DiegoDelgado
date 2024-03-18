export interface EventoInterface {
    eventoId: string,
    nombreInstitucion: string,
    direccionInstitucion: string,
    numeroAlumnos: number,
    fechaInicio: string,
    costoServicio: number,
    togaBirrete: boolean,
    fechaCreacion?: string,
    numeroReferencia?: string
}