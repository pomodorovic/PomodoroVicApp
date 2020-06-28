# PomodoroVicApp
Pomodoro application
<!--
Casos de prueba:
Ronda 1: (Casos normales)
- Pomodoro trabajo con fin normal
- Pomodoro descanso con fin normal

Ronda 2: (Casos finalizar)
- pomodoro trabajo + finalizar
- pomodoro descanso + finalizar
- Pomodoro ideal trabajo + finalizar
- Pomodoro ideal descanso + finalizar

Ronda 3: (Casos salir)
- Pomodoro trabajo + salir
- Pomodoro descanso + salir
- Pomodoro ideal trabajo + salir
- Pomodoro ideal descanso + salir

Ronda 4: (Casos reinicio)
- Pomodoro trabajo + reinicio a pomodoro descanso
- Pomodoro trabajo + reinicio a pomodoro ideal trabajo 
- Pomodoro trabajo + reinicio a pomodoro ideal descanso 
- Pomodoro descanso + reinicio a pomodoro trabajo
- Pomodoro descanso + reinicio a pomodoro ideal trabajo 
- Pomodoro descanso + reinicio a pomodoro ideal descanso 
- Pomodoro ideal trabajo + reinicio a pomodoro trabajo
- Pomodoro ideal trabajo + reinicio a pomodoro descanso
- Pomodoro ideal trabajo + reinicio a pomodoro ideal descanso 
- Pomodoro ideal descanso + reinicio a pomodoro trabajo
- Pomodoro ideal descanso + reinicio a pomodoro descanso
- Pomodoro ideal descanso + reinicio a pomodoro ideal trabajo 

Ronda 5: (Casos pausa + retomar)
- Pomodoro trabajo + pausa + retomar
- Pomodoro descanso + pausa + retomar
- Pomodoro ideal trabajo + pausa + retomar
- Pomodoro ideal descanso + pausa + retomar

// Version information for an assembly consists of the following four values:
//      Major Version
//      Minor Version
//      Build Number
//      Revision
-->
>Version 1.0.0.0 inicial, solo con botón de 25 minutos.
>
>Versión 2.0.0.0, minimalista, se añade estas funcionalidades:
- [x] Se rediseña pantalla principal para que sea minimalista
- [x] Se coloca menú contextual
- [x] Se coloca pantalla para que aparezca en la parte inferior derecha por default.
- [x] Se lee valores de configuración desde el app.config
- [x] Se crea opcion AutoIniciar para que cuando termine un pomodoro automaticamente comience otro (ej, finaliza 25 comienza en 5).
- [x] Se crea opcion Blink (seleccionado por default) para que alterne en colores si esta a 1 minuto o menos por finalizar el pomodoro.
- [x] Se añade notificador tooltip la cual se presenta en forma de alerta no intrusiva cuando tiempo a finalizado.
- [x] Se añade en label de hora fin, el pomodoro finalizado, con formato P: 5 o P:25
>Versión 2.1.0.0:
- [x] Se añade funcionalidad para personalizar tiempo descanso y break
- [x] Se añade funcionalidad para pausar o cancelar por teclado un pomodoro
>Versión 2.2.0.0:
- [x] Se añade funcionalidad para identificar pomodoro ideal
- [x] Se añade funcionalidad para guardar en log estadísticas
>Versión 2.3.0.0:
- [x] Se resuelven bug, que solo contaba 10 segundos y que al iniciar programa graba en log erroneamiente.
- [x] Se guarda log al salir
>Versión 2.4.0.0:
- [x] Se resuelven bug en opción: identificar pomodoro ideal, para que muestre horas si pasa de 60 minutos
- [x] Se corrige espacios demás que guardaba en log.
>Versión 2.5.0.0:
- [x] Detección de bloqueo de máquina, se coloca en pausa automáticamente
- [x] Si en identificar pomodoro ideal rebasa la 1 hora presenta notificación
>Versión 2.6.0.0:
- [x] Se corrige error, se queda marcado (checked) Pomodoro Pausa, cuando en pause se inicia cualquier tipo de pomodoro
- [x] Se cambia tonalidad de colores en diferentes pomodoro
- [x] Se mejora mensaje en Acerca de...
- [x] Se añade opción Identificar Pomodoro Ideal Descanso, y ahora se diferencia entre Pomodoro Ideal Trabajo y Pomodoro Ideal Descanso
- [x] Se corrige error, al iniciar no colocaba en checked la opacidad seleccionada, acorde a lo leido del archivo de configuración App.config
- [x] Se mejora la forma de guardar en el log para más adelante generar estadísticas


