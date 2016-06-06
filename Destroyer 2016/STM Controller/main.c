/**
 *	Keil project for USB HID Device
 *
 *	Before you start, select your target, on the right of the "Load" button
 *
 *	@author 	Tilen Majerle
 *	@email		tilen@majerle.eu
 *	@website	http://stm32f4-discovery.com
 *	@ide		Keil uVision 5
 */
/* Include core modules */
#include "stm32f4xx.h"
/* Include my libraries here */
#include "defines.h"
#include "tm_stm32f4_usb_hid_device.h"
#include "tm_stm32f4_delay.h"
#include "tm_stm32f4_disco.h"

#include "stm32f4_discovery_lis302dl.h"
#include "stm32f4xx_spi.h"

//Variables which represent of STM-board position on X-axis, Y-axis and Z-axis
int8_t acc_x, acc_y, acc_z;

void LIS302DL_Init1()
{
        LIS302DL_InitTypeDef LIS302DL_InitStruct;

        /*Set configuration of LIS302DL*/

        LIS302DL_InitStruct.Power_Mode=LIS302DL_LOWPOWERMODE_ACTIVE;

        LIS302DL_InitStruct.Output_DataRate=LIS302DL_DATARATE_100;

        LIS302DL_InitStruct.Axes_Enable = LIS302DL_X_ENABLE | LIS302DL_Y_ENABLE | LIS302DL_Z_ENABLE;

        LIS302DL_InitStruct.Full_Scale=LIS302DL_FULLSCALE_2_3;

        LIS302DL_InitStruct.Self_Test=LIS302DL_SELFTEST_NORMAL;

        LIS302DL_Init(&LIS302DL_InitStruct);

        //int i;
        //for (i=0;i<10000;i++);
}


int main(void) {
	uint8_t already = 0;

	/* Set structs for all examples */
	TM_USB_HIDDEVICE_Keyboard_t Keyboard;
	TM_USB_HIDDEVICE_Gamepad_t Gamepad1, Gamepad2;
	TM_USB_HIDDEVICE_Mouse_t Mouse;

	/* Initialize system */
	SystemInit();

	//Initialize LIS302DL - acceleration sensor;...
	//... the board position determines the movement of joystick

	LIS302DL_Init1();

	/* Initialize leds */
	TM_DISCO_LedInit();

	/* Initialize button */
	TM_DISCO_ButtonInit();

	/* Initialize delay */
	TM_DELAY_Init();

	/* Initialize USB HID Device */
	TM_USB_HIDDEVICE_Init();

	/* Set default values for mouse struct */
	TM_USB_HIDDEVICE_MouseStructInit(&Mouse);
	/* Set default values for keyboard struct */
	TM_USB_HIDDEVICE_KeyboardStructInit(&Keyboard);
	/* Set default values for gamepad structs */
	TM_USB_HIDDEVICE_GamepadStructInit(&Gamepad1);
	TM_USB_HIDDEVICE_GamepadStructInit(&Gamepad2);

	//Variables
	const int8_t axis_x_min = 0; //The number represents maximum deflection of left-stick on left; Default: -128 (!The value recommended for Unity game: 0 - Unity can read only not minus numbers of axis!)
	const int8_t axis_x_max = 127; //The number represents maximum deflection of left-stick on right; Default: 127
	const int8_t axis_x_avg = (axis_x_min + axis_x_max) / 2; //The value presented center position of left stick
	const int8_t acc_x_min = -60; //Minimum (approximately) value reading from accelerometer for X-axis
	const int8_t acc_x_max = 60; //Maximum (approximately) value reading from accelerometer for X-axis
	const int8_t kx = (-axis_x_min + axis_x_max) / (-acc_x_min + acc_x_max); //Thanks to this ratio, can create universal formula on value of gamepad left-axis depends on STM-board position

	const int8_t axis_y_min = 0; //The number represents maximum deflection of left-stick on top; Default: -128 (!The value recommended for Unity game: 0 - Unity can read only not minus numbers of axis!)
	const int8_t axis_y_max = 127; //The number represents maximum deflection of left-stick on bottom; Default: 127
	const int8_t axis_y_avg = (axis_y_min + axis_y_max) / 2; //The value presented center position of left stick
	const int8_t acc_y_min = -60; //Minimum (approximately) value reading from accelerometer for Y-axis
	const int8_t acc_y_max = 60; //Maximum (approximately) value reading from accelerometer for Y-axis
	const int8_t ky = (-axis_y_min + axis_y_max) / (-acc_y_min + acc_y_max); //Thanks to this ratio, can create universal formula on value of gamepad left-axis depends on STM-board position

	while (1) {
		/* If we are connected and drivers are OK */
		if (TM_USB_HIDDEVICE_GetStatus() == TM_USB_HIDDEVICE_Status_Connected) {
			/* Turn on green LED */
			TM_DISCO_LedOn(LED_GREEN);

/* Simple sketch start */

			/* If you pressed button right now and was not already pressed */
			if (TM_DISCO_ButtonPressed() && already == 0) { /* Button on press */
				already = 1;

				/* Gamepad 1 */
				/* Simulate button 1 on gamepad 1 */
				Gamepad1.Button1 = TM_USB_HIDDEVICE_Button_Pressed;

				/* Send report for gamepad 1 */
				TM_USB_HIDDEVICE_GamepadSend(TM_USB_HIDDEVICE_Gamepad_Number_1, &Gamepad1);


			} else if (!TM_DISCO_ButtonPressed() && already == 1) { /* Button on release */
				already = 0;

				//I thought the command that is 5 lines below was sufficient but no...
				//I released blue button but computer "thought" I still pressed it.
				Gamepad1.Button1 = TM_USB_HIDDEVICE_Button_Released; //release button 1

				/* Send command to release all buttons on both gamepads */
				TM_USB_HIDDEVICE_GamepadReleaseAll(TM_USB_HIDDEVICE_Gamepad_Number_1);
			}

			// Read the board position on axes
			LIS302DL_Read(&acc_x,LIS302DL_OUT_X_ADDR,1);
			LIS302DL_Read(&acc_y,LIS302DL_OUT_Y_ADDR,1);
			LIS302DL_Read(&acc_z,LIS302DL_OUT_Z_ADDR,1);

			//The value on axis depends on board lean
			//HERE: Changing orientation of left joystick under the influence of X-axis

			/* Simulate left stick rotation */
			/* X axis */
			if (acc_x > -15 && acc_x < 15) //horizontal position of STM-board
			{
				Gamepad1.LeftXAxis = axis_x_avg;
			}
			else
			{
				if (acc_x >= acc_x_max - 10) //maximum right position --> vertical position of STM-board (USB mini-B on top of board)
				{
					Gamepad1.LeftXAxis = axis_x_max;
				}
				else
				{
					if (acc_x <= acc_x_min + 10) //maximum left position --> vertical position of STM-board (mini-jack out and USB micro-B on top )
					{
						Gamepad1.LeftXAxis = axis_x_min;
					}
					else
					{
						Gamepad1.LeftXAxis = acc_x * kx + axis_x_avg; //universal formula on left-stick position of gamepad depending on STM position
						//it seems to be sufficient (without if-conditionals); but using of "if", it ensures more stability
					}
				}
			}

			/* Y axis */
			if (acc_y > -15 && acc_y < 15) //horizontal position of STM-board
						{
							Gamepad1.LeftYAxis = axis_y_avg;
						}
						else
						{
							if (acc_y >= acc_x_max - 10) //maximum "up" position --> blue button of STM is higher than black reset-button
							{
								Gamepad1.LeftYAxis = axis_y_min;
							}
							else
							{
								if (acc_y <= acc_x_min + 10) //maximum "down" position --> black button of STM is higher than blue button
								{
									Gamepad1.LeftYAxis = axis_y_max;
								}
								else
								{
									Gamepad1.LeftYAxis = acc_y * (-ky) + axis_y_avg; //universal formula on left-stick position of gamepad depending on STM position
									//it seems to be sufficient (without if-conditionals); but using of "if", it ensures more stability
								}
							}
						}

			TM_USB_HIDDEVICE_GamepadSend(TM_USB_HIDDEVICE_Gamepad_Number_1, &Gamepad1);

/* Simple sketch end */

		} else {
			/* Turn off green LED */
			TM_DISCO_LedOff(LED_GREEN);
		}
	}
}
