# VR-Bow-26-G6

Un simulador de arco para realidad virtual, desarrollado con Unity y los plugins Auto Hand y XR Interaction Toolkit.

- **Interacción con Auto Hand**: Agarra, tensa y suelta la cuerda del arco con *Auto Hand*.
- **Sistema de Cuerda Dinámica (Create String)**: La cuerda del arco se genera proceduralmente y modifica sus parámetros en tiempo real mediante script, simulando la tensión realista de un arco.
- **Disparo de Flechas**: Tensa la cuerda y suéltala para disparar flechas hacia los objetivos.
- **Sistema de Objetivos**: Los objetivos (MovingTarget) reciben impacto, reducen su salud y se reinician automáticamente tras 3 segundos.

## Mecánicas del Arco

| Mecánica | Descripción |
|----------|-------------|
| Tensado | Agarra la cuerda con Auto Hand y tira hacia atrás |
| Disparo | Suelta la cuerda para lanzar la flecha |
| Distancia de Tensado | Afecta la velocidad y potencia del disparo |
| Posición de la Flecha | La flecha se posiciona automáticamente en la cuerda |

## Controles (VR)

| Acción | Input |
|--------|-------|
| Agarrar el arco | Gatillo |
| Agarrar la cuerda | Gatillo |
| Tensar la cuerda | Mover la mano hacia atrás mientras se agarra |
| Disparar | Soltar el gatillo (cuerda) |

## Tecnologías Usadas

- **Unity** (versión 6)
- **Auto Hand** (Plugin para interacción VR con manos realistas)
- **XR Interaction Toolkit** (Interacciones base y XRGrabInteractable)
- **Create String** (Generación procedural de la cuerda)
- **Física de Unity** (Rigidbody, Colliders, detección de colisiones)
