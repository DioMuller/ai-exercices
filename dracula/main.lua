screenWidth = 640
screenHeight = 480

function love.load()
	-- Sets window parameters.
	love.window.setTitle("Boss Battle - Dracula")
	love.window.setMode(screenWidth,screenHeight, {resizable=false, vsync=true, minwidth=screenWidth, minheight=screenHeight})

	-- Load assets.
	background = love.graphics.newImage("assets/background.png")
	backgroundScaleX = screenWidth / background.getWidth(background)
	backgroundScaleY = screenHeight / background.getHeight(background)
end

function love.draw()
	love.graphics.draw(background, 0, 0, 0, backgroundScaleX, backgroundScaleY)
end