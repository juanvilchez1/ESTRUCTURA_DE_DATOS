from typing import Dict, Set, List
import time
import random

class Jugador:
    def __init__(self, id: int, nombre: str, edad: int, posicion: str):
        self.id = id
        self.nombre = nombre
        self.edad = edad
        self.posicion = posicion
    
    def __str__(self) -> str:
        return f"ID: {self.id}, Nombre: {self.nombre}, Edad: {self.edad}, Posición: {self.posicion}"
    
    def __hash__(self) -> int:
        return hash(self.id)  # Usamos el ID como hash para poder usar jugadores en conjuntos
    
    def __eq__(self, other) -> bool:
        if not isinstance(other, Jugador):
            return False
        return self.id == other.id

class Equipo:
    def __init__(self, id: int, nombre: str, ciudad: str):
        self.id = id
        self.nombre = nombre
        self.ciudad = ciudad
        self.jugadores: Set[Jugador] = set()  # Conjunto de jugadores
    
    def agregar_jugador(self, jugador: Jugador) -> bool:
        if len(self.jugadores) >= 23:  # Limitamos a 23 jugadores por equipo
            return False
        self.jugadores.add(jugador)
        return True
    
    def eliminar_jugador(self, id_jugador: int) -> bool:
        for jugador in self.jugadores:
            if jugador.id == id_jugador:
                self.jugadores.remove(jugador)
                return True
        return False
    
    def __str__(self) -> str:
        return f"ID: {self.id}, Nombre: {self.nombre}, Ciudad: {self.ciudad}, Jugadores: {len(self.jugadores)}"

class Torneo:
    def __init__(self, nombre: str):
        self.nombre = nombre
        self.equipos: Dict[int, Equipo] = {}  # Mapa de ID -> Equipo
        self.jugadores_registrados: Set[int] = set()  # Conjunto de IDs de jugadores registrados
    
    def registrar_equipo(self, equipo: Equipo) -> bool:
        if equipo.id in self.equipos:
            return False
        self.equipos[equipo.id] = equipo
        return True
    
    def eliminar_equipo(self, id_equipo: int) -> bool:
        if id_equipo not in self.equipos:
            return False
        
        # Liberamos los IDs de los jugadores del equipo
        for jugador in self.equipos[id_equipo].jugadores:
            self.jugadores_registrados.discard(jugador.id)
            
        # Eliminamos el equipo
        del self.equipos[id_equipo]
        return True
    
    def buscar_equipo(self, id_equipo: int) -> Equipo:
        return self.equipos.get(id_equipo)
    
    def registrar_jugador(self, id_equipo: int, jugador: Jugador) -> bool:
        # Verificamos que el ID del jugador no esté ya registrado en el torneo
        if jugador.id in self.jugadores_registrados:
            return False
            
        equipo = self.buscar_equipo(id_equipo)
        if not equipo:
            return False
            
        if equipo.agregar_jugador(jugador):
            self.jugadores_registrados.add(jugador.id)
            return True
        return False
    
    def transferir_jugador(self, id_jugador: int, id_equipo_origen: int, id_equipo_destino: int) -> bool:
        if id_equipo_origen not in self.equipos or id_equipo_destino not in self.equipos:
            return False
            
        equipo_origen = self.equipos[id_equipo_origen]
        equipo_destino = self.equipos[id_equipo_destino]
        
        # Buscamos el jugador en el equipo de origen
        jugador_transferir = None
        for jugador in equipo_origen.jugadores:
            if jugador.id == id_jugador:
                jugador_transferir = jugador
                break
                
        if not jugador_transferir:
            return False
            
        # Intentamos agregar al jugador al equipo destino
        if equipo_destino.agregar_jugador(jugador_transferir):
            # Si se agrega exitosamente, lo eliminamos del equipo origen
            equipo_origen.eliminar_jugador(id_jugador)
            return True
        return False
    
    def listar_equipos(self) -> List[Equipo]:
        return list(self.equipos.values())
    
    def listar_jugadores_equipo(self, id_equipo: int) -> List[Jugador]:
        if id_equipo not in self.equipos:
            return []
        return list(self.equipos[id_equipo].jugadores)
    
    def buscar_jugador_por_id(self, id_jugador: int) -> (Jugador, Equipo):
        """Busca un jugador por su ID y devuelve el jugador y el equipo al que pertenece"""
        for id_equipo, equipo in self.equipos.items():
            for jugador in equipo.jugadores:
                if jugador.id == id_jugador:
                    return jugador, equipo
        return None, None
    
    def __str__(self) -> str:
        return f"Torneo: {self.nombre}, Equipos: {len(self.equipos)}, Jugadores: {len(self.jugadores_registrados)}"

# Interfaz de usuario
def mostrar_menu():
    print("\n===== SISTEMA DE REGISTRO DE TORNEO DE FÚTBOL =====")
    print("1. Registrar equipo")
    print("2. Listar equipos")
    print("3. Registrar jugador")
    print("4. Listar jugadores de un equipo")
    print("5. Transferir jugador")
    print("6. Eliminar equipo")
    print("7. Buscar jugador por ID")
    print("8. Análisis de rendimiento")
    print("9. Salir")
    return input("Seleccione una opción: ")

def main():
    torneo = Torneo("Liga Fútbol 2023")
    
    while True:
        opcion = mostrar_menu()
        
        if opcion == "1":
            id_equipo = int(input("ID del equipo: "))
            nombre = input("Nombre del equipo: ")
            ciudad = input("Ciudad del equipo: ")
            
            equipo = Equipo(id_equipo, nombre, ciudad)
            if torneo.registrar_equipo(equipo):
                print(f"Equipo '{nombre}' registrado exitosamente.")
            else:
                print(f"Error: Ya existe un equipo con el ID {id_equipo}.")
                
        elif opcion == "2":
            equipos = torneo.listar_equipos()
            if not equipos:
                print("No hay equipos registrados.")
            else:
                print("\n=== EQUIPOS REGISTRADOS ===")
                for equipo in equipos:
                    print(equipo)
                    
        elif opcion == "3":
            id_equipo = int(input("ID del equipo al que pertenecerá el jugador: "))
            equipo = torneo.buscar_equipo(id_equipo)
            
            if not equipo:
                print(f"Error: No existe un equipo con el ID {id_equipo}.")
                continue
                
            id_jugador = int(input("ID del jugador: "))
            nombre = input("Nombre del jugador: ")
            edad = int(input("Edad del jugador: "))
            posicion = input("Posición del jugador: ")
            
            jugador = Jugador(id_jugador, nombre, edad, posicion)
            if torneo.registrar_jugador(id_equipo, jugador):
                print(f"Jugador '{nombre}' registrado exitosamente en el equipo '{equipo.nombre}'.")
            else:
                print(f"Error: No se pudo registrar al jugador. El ID ya está en uso o el equipo está completo.")
                
        elif opcion == "4":
            id_equipo = int(input("ID del equipo: "))
            jugadores = torneo.listar_jugadores_equipo(id_equipo)
            
            if not jugadores:
                print(f"No hay jugadores registrados en este equipo o el equipo no existe.")
            else:
                equipo = torneo.buscar_equipo(id_equipo)
                print(f"\n=== JUGADORES DEL EQUIPO '{equipo.nombre}' ===")
                for jugador in jugadores:
                    print(jugador)
                    
        elif opcion == "5":
            id_jugador = int(input("ID del jugador a transferir: "))
            id_equipo_origen = int(input("ID del equipo de origen: "))
            id_equipo_destino = int(input("ID del equipo de destino: "))
            
            if torneo.transferir_jugador(id_jugador, id_equipo_origen, id_equipo_destino):
                print("Jugador transferido exitosamente.")
            else:
                print("Error: No se pudo realizar la transferencia.")
                
        elif opcion == "6":
            id_equipo = int(input("ID del equipo a eliminar: "))
            
            if torneo.eliminar_equipo(id_equipo):
                print("Equipo eliminado exitosamente.")
            else:
                print(f"Error: No existe un equipo con el ID {id_equipo}.")
                
        elif opcion == "7":
            id_jugador = int(input("ID del jugador a buscar: "))
            jugador, equipo = torneo.buscar_jugador_por_id(id_jugador)
            
            if jugador:
                print(f"\nJugador encontrado en el equipo '{equipo.nombre}':")
                print(jugador)
            else:
                print(f"No se encontró ningún jugador con el ID {id_jugador}.")
                
        elif opcion == "8":
            realizar_analisis_rendimiento(torneo)
                
        elif opcion == "9":
            print("¡Gracias por usar el Sistema de Registro de Torneo de Fútbol!")
            break
            
        else:
            print("Opción no válida. Intente nuevamente.")

def generar_datos_prueba(n_equipos=10, n_jugadores_por_equipo=20):
    """Genera datos de prueba para análisis de rendimiento"""
    torneo = Torneo("Torneo Prueba")
    
    # Nombres de ejemplo
    nombres_equipos = ["Real Madrid", "Barcelona", "Liverpool", "Bayern", "PSG", 
                      "Juventus", "Manchester City", "Chelsea", "Ajax", "Porto",
                      "Boca Juniors", "River Plate", "Flamengo", "América", "Chivas"]
    
    ciudades = ["Madrid", "Barcelona", "Liverpool", "Munich", "París",
               "Turín", "Manchester", "Londres", "Amsterdam", "Oporto",
               "Buenos Aires", "Buenos Aires", "Río de Janeiro", "Ciudad de México", "Guadalajara"]
    
    nombres_jugadores = ["Juan", "Carlos", "Pedro", "Luis", "Miguel", "Antonio", "Fernando",
                         "Roberto", "Javier", "Ricardo", "Diego", "Sergio", "Alejandro", "Rafael",
                         "Manuel", "David", "José", "Francisco", "Andrés", "Jorge"]
    
    apellidos = ["García", "Rodríguez", "Martínez", "López", "González", "Pérez", "Sánchez",
                "Ramírez", "Torres", "Flores", "Rivera", "Gómez", "Díaz", "Reyes", "Morales",
                "Cruz", "Ortiz", "Gutiérrez", "Mendoza", "Ruiz"]
    
    posiciones = ["Portero", "Defensa Central", "Lateral Derecho", "Lateral Izquierdo", 
                 "Mediocentro", "Centrocampista", "Extremo Derecho", "Extremo Izquierdo", "Delantero"]
    
    # Generar equipos
    for i in range(n_equipos):
        id_equipo = i + 1
        nombre = random.choice(nombres_equipos) + " " + str(id_equipo)
        ciudad = random.choice(ciudades)
        equipo = Equipo(id_equipo, nombre, ciudad)
        torneo.registrar_equipo(equipo)
        
        # Generar jugadores para cada equipo
        for j in range(n_jugadores_por_equipo):
            id_jugador = i * 100 + j + 1
            nombre = random.choice(nombres_jugadores) + " " + random.choice(apellidos)
            edad = random.randint(18, 35)
            posicion = random.choice(posiciones)
            jugador = Jugador(id_jugador, nombre, edad, posicion)
            torneo.registrar_jugador(id_equipo, jugador)
    
    return torneo

def realizar_analisis_rendimiento(torneo_real):
    print("\n=== ANÁLISIS DE RENDIMIENTO ===")
    print("Generando datos para pruebas de rendimiento...")
    
    # Prueba 1: Registro masivo de equipos y jugadores
    print("\nPrueba 1: Tiempo para generar y registrar datos")
    inicio = time.time()
    torneo_prueba = generar_datos_prueba(n_equipos=50, n_jugadores_por_equipo=23)
    fin = time.time()
    print(f"Tiempo para registrar 50 equipos con 23 jugadores cada uno: {fin - inicio:.5f} segundos")
    print(f"Total de equipos: {len(torneo_prueba.equipos)}")
    print(f"Total de jugadores: {len(torneo_prueba.jugadores_registrados)}")
    
    # Prueba 2: Búsqueda de jugadores por ID
    print("\nPrueba 2: Tiempo de búsqueda de jugadores por ID")
    ids_aleatorios = random.sample(list(torneo_prueba.jugadores_registrados), 100)
    
    inicio = time.time()
    encontrados = 0
    for id_jugador in ids_aleatorios:
        jugador, _ = torneo_prueba.buscar_jugador_por_id(id_jugador)
        if jugador:
            encontrados += 1
    fin = time.time()
    print(f"Tiempo para buscar 100 jugadores aleatorios: {fin - inicio:.5f} segundos")
    print(f"Jugadores encontrados: {encontrados}")
    
    # Prueba 3: Transferencias de jugadores
    print("\nPrueba 3: Tiempo para realizar transferencias")
    transferencias_exitosas = 0
    transferencias_totales = 100
    
    inicio = time.time()
    for _ in range(transferencias_totales):
        id_equipo_origen = random.randint(1, 50)
        id_equipo_destino = random.randint(1, 50)
        while id_equipo_destino == id_equipo_origen:
            id_equipo_destino = random.randint(1, 50)
            
        # Buscamos un jugador aleatorio del equipo origen
        jugadores_equipo = torneo_prueba.listar_jugadores_equipo(id_equipo_origen)
        if jugadores_equipo:
            jugador_aleatorio = random.choice(jugadores_equipo)
            if torneo_prueba.transferir_jugador(jugador_aleatorio.id, id_equipo_origen, id_equipo_destino):
                transferencias_exitosas += 1
    fin = time.time()
    
    print(f"Tiempo para intentar {transferencias_totales} transferencias: {fin - inicio:.5f} segundos")
    print(f"Transferencias exitosas: {transferencias_exitosas}")
    
    # Resumen del análisis
    print("\n=== RESUMEN DE ESTRUCTURAS UTILIZADAS ===")
    print("1. Diccionario (Map) para almacenar equipos: O(1) acceso promedio")
    print("2. Conjunto (Set) para almacenar jugadores en equipos: O(1) verificación de pertenencia promedio")
    print("3. Conjunto (Set) para controlar IDs de jugadores registrados: O(1) verificación de pertenencia promedio")
    
    print("\nVentajas de las estructuras utilizadas:")
    print("- Acceso rápido a equipos por ID mediante diccionarios (tiempo constante)")
    print("- Verificación eficiente de jugadores ya registrados mediante conjuntos")
    print("- Prevención de duplicados de IDs de jugadores")
    print("- Operaciones de agregación y eliminación eficientes")
    
    print("\nDesventajas:")
    print("- Mayor consumo de memoria comparado con arreglos simples")
    print("- La búsqueda de jugadores por ID requiere iteración sobre todos los equipos (tiempo lineal)")
    print("- No hay indexación secundaria (por ejemplo, buscar jugadores por nombre)")

if __name__ == "__main__":
    main()