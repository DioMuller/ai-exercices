require "boss"


-- Screen Info/Parameters
screen = 
{ 
	width = 640, 
	height = 480 
}

-- Loads assets and initializes game.
function love.load()
	-- Sets window parameters.
	love.window.setTitle("Boss Battle - Dracula")
	love.window.setMode(screen.width,screen.height, {resizable=false, vsync=true, minwidth=screen.width, minheight=screen.height})

	-- Load assets.
	background = love.graphics.newImage("assets/backgrounds/background.png")
	backgroundScaleX = screen.width / background.getWidth(background)
	backgroundScaleY = screen.height / background.getHeight(background)
	
	initializeBossStates()
end

-- Drawing function
function love.draw()
	love.graphics.draw(background, 0, 0, 0, backgroundScaleX, backgroundScaleY)
	drawState(screen.width / 2, screen.height / 2, backgroundScaleX, backgroundScaleY)

	love.graphics.print("Boss Health: " .. boss.hp, 10, 10)
	love.graphics.print("Current State: " .. boss.current_state.description, 10, 25)
	love.graphics.print("Next State in " .. round(boss.wait_time, 1) .. " seconds", 10, 40)
end

-- Update Function
function love.update(dt)
	if love.keyboard.isDown(" ") then -- hits enemy with SPACE
		attackBoss()
	elseif love.keyboard.isDown("escape") then -- quits game with ESC
		love.event.quit()
	end
	
	updateBoss(dt)
end