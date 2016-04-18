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

int8_t left_joystick()
{
				LIS302DL_Read(&acc_x,LIS302DL_OUT_X_ADDR,1);
				LIS302DL_Read(&acc_y,LIS302DL_OUT_Y_ADDR,1);
				LIS302DL_Read(&acc_z,LIS302DL_OUT_Z_ADDR,1);

				int8_t x = 0;

				if(acc_y > 20)
				{
					/* Simulate left stick rotation */
					x = 50; /* X axis */
					//Gamepad1.LeftYAxis = 30; /* Y axis */
				}
				if(acc_y < -20)
				{
					/* Simulate left stick rotation */
					x = -50; /* X axis */
					//Gamepad1.LeftYAxis = 30; /* Y axis */
				}
				if(acc_y <= 20 && acc_y >= -20)
				{
					/* Simulate left stick rotation */
					x = 0; /* X axis */
					//Gamepad1.RightXAxis = 0; /* X axis */
					//Gamepad1.LeftYAxis = 30; /* Y axis */
				}

				return x;

}

int main(void) {
	uint8_t already = 0;

	/* Set structs for all examples */
	TM_USB_HIDDEVICE_Keyboard_t Keyboard;
	TM_USB_HIDDEVICE_Gamepad_t Gamepad1, Gamepad2;
	TM_USB_HIDDEVICE_Mouse_t Mouse;

	/* Initialize system */
	SystemInit();

	/* Initialize LIS302DL - acceleration sensor;
	 * the board position determines the movement of joystick
	 * --(own)
	 * */
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

				//I think the command that is 5 lines below is sufficient but no...
				//I release blue button but computer "thinks" I still press it.
				Gamepad1.Button1 = TM_USB_HIDDEVICE_Button_Released;

				/* Send command to release all buttons on both gamepads */
				TM_USB_HIDDEVICE_GamepadReleaseAll(TM_USB_HIDDEVICE_Gamepad_Number_1);
			}


			/* Read the board position on axes
			 * --(own)
			 * */
			LIS302DL_Read(&acc_x,LIS302DL_OUT_X_ADDR,1);
			LIS302DL_Read(&acc_y,LIS302DL_OUT_Y_ADDR,1);
			LIS302DL_Read(&acc_z,LIS302DL_OUT_Z_ADDR,1);

			/* The value on axis depends on board lean
			 * HERE: Changing orientation of left joystick under the influence of X-axis
			* --(own)
			* */
			if(acc_x > 40)
			{
				/* Simulate left stick rotation */
				Gamepad1.LeftXAxis = -127; /* X axis */
			}
			if(acc_x < -40)
			{
				/* Simulate left stick rotation */
				Gamepad1.LeftXAxis = 127; /* X axis */
			}
			if(acc_x <= 40 && acc_x >= -40)
			{
				/* Simulate left stick rotation */
				Gamepad1.LeftXAxis = NULL; /* X axis */
			}

			TM_USB_HIDDEVICE_GamepadSend(TM_USB_HIDDEVICE_Gamepad_Number_1, &Gamepad1);

/* Simple sketch end */

		} else {
			/* Turn off green LED */
			TM_DISCO_LedOff(LED_GREEN);
		}
	}
}
