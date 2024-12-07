#include <iostream>
#include <cmath> // Para usar M_PI

// Clase para representar un círculo
class Circulo {
private:
    double radio; // Atributo privado para el radio del círculo

public:
    // Constructor
    Circulo(double r) {
        radio = r;
    }

    // Método para calcular el área
    double calcularArea() {
        return M_PI * radio * radio; // Fórmula: π * r^2
    }

    // Método para calcular el perímetro
    double calcularPerimetro() {
        return 2 * M_PI * radio; // Fórmula: 2 * π * r
    }
};

// Clase para representar un rectángulo
class Rectangulo {
private:
    double largo, ancho; // Atributos privados para largo y ancho

public:
    // Constructor
    Rectangulo(double l, double a) {
        largo = l;
        ancho = a;
    }

    // Método para calcular el área
    double calcularArea() {
        return largo * ancho; // Fórmula: largo * ancho
    }

    // Método para calcular el perímetro
    double calcularPerimetro() {
        return 2 * (largo + ancho); // Fórmula: 2 * (largo + ancho)
    }
};

// Función principal
int main() {
    // Crear un círculo con radio 5
    Circulo miCirculo(5.0);
    std::cout << "Círculo:" << std::endl;
    std::cout << "Área: " << miCirculo.calcularArea() << std::endl;
    std::cout << "Perímetro: " << miCirculo.calcularPerimetro() << std::endl;

    // Crear un rectángulo con largo 4 y ancho 3
    Rectangulo miRectangulo(4.0, 3.0);
    std::cout << "\nRectángulo:" << std::endl;
    std::cout << "Área: " << miRectangulo.calcularArea() << std::endl;
    std::cout << "Perímetro: " << miRectangulo.calcularPerimetro() << std::endl;

    return 0;
}
