require "libs/case"

screenWidth = 640
screenHeight = 480

-- Dracula States
STATE_INITIAL = "Initial"
STATE_WAITING = "Waiting"
STATE_BEINGHIT = "Being Hit"
STATE_NORMAL_FIREBALL = "Throwing Fireball (As Dracula)"
STATE_NORMAL_ENERGYBALL = "Throwing Energy Ball (As Dracula)"
STATE_NORMAL_TELEPORT = "Teleporting (As Dracula)"
STATE_NORMAL_TRANSFORMING = "Transforming into monster (As Dracula)"
STATE_MONSTER_DECIDING = "Deciding next move (As Monster)"
STATE_MONSTER_JUMPING = "Jumping (As Monster)"
STATE_MONSTER_FIREBALL = "Throwing Fireball (As Monster)"
STATE_MONSTER_DYING = "Dying (As Monster)"
STATE_DEAD = "Dead!"

hp = 10
is_moster = false
wait_time = 1.0
current_state = STATE_INITIAL
last_state = STATE_INITIAL
remaining_time = 0.0

-- Loads assets and initializes game.
function love.load()
	-- Sets window parameters.
	love.window.setTitle("Boss Battle - Dracula")
	love.window.setMode(screenWidth,screenHeight, {resizable=false, vsync=true, minwidth=screenWidth, minheight=screenHeight})

	-- Load assets.
	background = love.graphics.newImage("assets/background.png")
	backgroundScaleX = screenWidth / background.getWidth(background)
	backgroundScaleY = screenHeight / background.getHeight(background)
end

-- Drawing function
function love.draw()
	love.graphics.draw(background, 0, 0, 0, backgroundScaleX, backgroundScaleY)

	love.graphics.print("Next State in " .. wait_time .. " seconds", 10, 25)
	
	love.graphics.print(current_state, 10, 10)
end

-- Update Function
function love.update(dt)
	wait_time = wait_time - dt;
	
	if( wait_time <= 0 ) then
		switch(current_state) 
		{
			[STATE_INITIAL] =
				function()
					current_state = STATE_NORMAL_TELEPORT
					wait_time = 1.0
				end,
			[STATE_WAITING] =
				function()
					if is_moster then						
						current_state = STATE_MONSTER_DECIDING
					else
						current_state = STATE_NORMAL_TELEPORT
					end
					wait_time = 1.0
				end,
			[STATE_BEINGHIT] =
				function()
					hp = hp - 1
					
					if hp <= 5 then -- Transforms at half HP.
						current_state = STATE_NORMAL_TRANSFORMING
					else
						current_state = last_state
						wait_time = remaining_time
					end
				end,
			[STATE_NORMAL_FIREBALL] =
				function()
					current_state = STATE_WAITING
					wait_time = 3.0
				end,
			[STATE_NORMAL_ENERGYBALL] =
				function()
					current_state = STATE_WAITING
					wait_time = 3.0
				end,
			[STATE_NORMAL_TELEPORT] =
				function()
					if math.random() > 0.7	then
						current_state = STATE_NORMAL_ENERGYBALL
					else
						current_state = STATE_NORMAL_FIREBALL
					end
					wait_time = 1.0
				end,
			[STATE_NORMAL_TRANSFORMING] =
				function()
					is_moster = true
					current_state = STATE_MONSTER_DECIDING
					wait_time = 1.0
				end,
			[STATE_MONSTER_DECIDING] =
				function()
					if math.random() > 0.6	then
						current_state = STATE_MONSTER_JUMPING
					else
						current_state = STATE_MONSTER_FIREBALL
					end
					wait_time = 1.0
				end,
			[STATE_MONSTER_JUMPING] =
				function()
					current_state = STATE_WAITING
					wait_time = 3.0
				end,
			[STATE_MONSTER_FIREBALL] =
				function()
					current_state = STATE_WAITING
					wait_time = 3.0
				end,
			[STATE_MONSTER_DYING] =
				function()
					current_state = STATE_DEAD
					wait_time = 5.0
				end,
			[STATE_DEAD] =
				function()
					current_state = STATE_DEAD
					wait_time = 5.0
				end,
			[Default] =
				function()
				end,
			[Nil] =
				function()
				end
		}
	end
end